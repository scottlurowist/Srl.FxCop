//
// BaseCustomFxCopRule.cs
//
// Product: 
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: Represents the base class for all custom developer written rules. It provides a 
//              layer of abstraction to the FxCop SDK.
//
// Author: Scott Lurowist
//
//




#region Using Directives

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.FxCop.Sdk;

#endregion




namespace Srl.FxCop.CustomRuleSdk
{
    /// <summary>
    /// Represents the base class for all custom developer written rules. It provides a 
    /// layer of abstraction to the FxCop SDK.
    /// </summary>
    public class BaseCustomFxCopRule : BaseIntrospectionRule
    {

        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of BaseDeveloperTestRule with the 
        /// rule metadata 
        /// </summary>
        /// <param name="ruleName">
        /// The name of the rule that a subclass implements.
        /// </param>
        /// <param name="resourceName">
        /// The name of the XML file that contains the rule metadata.
        /// </param>
        /// <param name="assembly">
        /// The assembly type that implements the current rule.
        /// </param>
        protected BaseCustomFxCopRule(string ruleName, string resourceName, Assembly assembly)
            : base(ruleName, resourceName, assembly)
        {
        }

        #endregion




        #region Protected Helper Methods

        /// <summary>
        /// Gets the named resolution for the current problem and add it to
        /// the problem collection.
        /// </summary>
        /// <param name="resolutionName">
        /// The name of the resolution to the problem that was found. This will
        /// always correspond with the Resolution name equals tag in the 
        /// rules metadata XML file.
        /// </param>
        /// <param name="resolutionParameters">
        /// Parameters to the named resolution.
        /// </param>
        /// <param name="stringId">
        /// A unique value that allows each invocation of a Check method to add multiple
        /// problems to the Problem collection.
        /// </param>
        private void AddProblem(string resolutionName, string[] resolutionParameters, string stringId)
        {
            Problems.Add(new Problem(GetNamedResolution(resolutionName, resolutionParameters), stringId ));
        }


        /// <summary>
        /// Processes the problems found by a rule.
        /// </summary>
        /// <param name="problemsFound">
        /// A list of CustomProblem that represents problems found by a rule.
        /// </param>
        protected void ProcessFoundProblems(IList<CustomProblem> problemsFound)
        {
            // Creates a unique string ID so that multiple problems can be added
            // to the Problems collection for each Check method invocation.
            int stringId = 0;

            foreach (var customProblem in problemsFound)
            {
                AddProblem(customProblem.ResolutionName, customProblem.ResolutionArguments, stringId.ToString());

                stringId++;
            }
        }


        /// <summary>
        /// Converts an FxCop InInstructionCollection instance to an IList of CustomInstruction
        /// so that custom rules can be unit tested. This method isolates custome rules from the
        /// FxCop environment.
        /// </summary>
        /// <param name="instructions">
        /// A collection of FxCop SDK Instruction instances.
        /// </param>
        /// <returns>
        /// An instance of IList of CustomInstruction that contains the converted
        /// </returns>
        protected IList<CustomInstruction> 
            GetCustomInstructionListFromInstructionCollection(InstructionCollection instructions)
        {
            if (instructions == null)
                throw new ArgumentNullException("instructions", "instructions cannot be null.");

            IList<CustomInstruction> instructionList = new List<CustomInstruction>();

            foreach (Instruction fxCopInstruction in instructions)
            {
                var currentInstruction = new CustomInstruction();
                currentInstruction.Offset = fxCopInstruction.Offset;
                currentInstruction.OpCode = fxCopInstruction.OpCode;

                var localValue = fxCopInstruction.Value as Local;

                if (localValue == null)
                {
                    currentInstruction.Value = fxCopInstruction.Value;
                }
                else
                {
                    currentInstruction.Value = new CustomLocal() { Name = localValue.Name.Name };                   
                }

                instructionList.Add(currentInstruction);
            }

            return instructionList;
        }


        /// <summary>
        /// Takes an instance of Member that represents a method and returns a list of 
        /// CustomField that represents fields belonging to the method's class instance.
        /// </summary>
        /// <param name="classType">
        /// An type of the class that has declare the fields of interest.
        /// </param>
        /// <returns>
        /// A list of CustomField containg the fields of the type's class instance. If the
        /// class has no fields, then an empty List is returned.
        /// </returns>
        protected IList<CustomField> GetListOfCustomFieldsForTheType(TypeNode classType)
        {
            if (classType == null)
                throw new ArgumentNullException("classType", "classType cannot be null.");

            var fieldList = new List<CustomField>();

            MemberCollection members = classType.Members;

            foreach (Member member in members)
            {
                var fieldCandidate = member as Field;

                if (fieldCandidate != null)
                    fieldList.Add(ConvertFxCopSdkFieldToCustomField(fieldCandidate));
            }

            return fieldList;
        }


        /// <summary>
        /// Converts an FxCop SDK Field instance to an instance of CustomField.
        /// </summary>
        /// <param name="fieldToConvert">
        /// The Field instance to be converted to CustomField.
        /// </param>
        /// <returns>
        /// An instance of CustomField that represents fieldToConvert.
        /// </returns>
        protected CustomField ConvertFxCopSdkFieldToCustomField(Field fieldToConvert)
        {
            if (fieldToConvert == null)
                throw new ArgumentNullException("fieldToConvert", "fieldToConvert cannot be null.");

            var newField = new CustomField();

            newField.DefaultValue = fieldToConvert.DefaultValue;
            newField.Flags = fieldToConvert.Flags;
            newField.FullName = fieldToConvert.FullName;
            newField.InitialData = fieldToConvert.InitialData;
            //newField.ToString()

            return newField;
        }


        /// <summary>
        /// Checks if the method represented by Member has the named attribute.
        /// </summary>
        /// <param name="methodToCheck">
        /// Thye method to be check for the presence of an attribute.
        /// </param>
        /// <param name="attributeName">
        /// The name of the attribute being checked for existince.
        /// </param>
        /// <returns>
        /// true if the method has the named attribute; otherwise, false.
        /// </returns>
        protected bool DoesMethodHaveAnAttribute(Method methodToCheck, string attributeName)
        {
            if (methodToCheck == null)
                throw new ArgumentNullException("methodToCheck", "methodToCheck cannot be null.");

            if (attributeName == null)
                throw new ArgumentNullException("attributeName", "attributeName cannot be null.");

            bool checkResult = false;

            foreach (var attribute in methodToCheck.Attributes)
            {
                if (attribute.Type.ConstructorName.Name == attributeName)
                    checkResult = true;              
            }

            return checkResult;
        }


        /// <summary>
        /// Get a list of custom instruction for a member that is specified 
        /// </summary>
        /// <param name="classType">
        /// The class type that contains the method for which its instructions are to be returned.
        /// </param>
        /// <param name="attributeName">
        /// The name of an attribute that uniquely specifies a method. This attribute should be 
        /// unique in the class.
        /// </param>
        /// <returns>
        /// The list of instructions for the first method found with the attribute name; otherwise, 
        /// an empty list.
        /// </returns>
        protected IList<CustomInstruction> GetListOfCustomInstructionForMethodByUniqueAttributeNameAndClassType(TypeNode classType, 
            string attributeName)
        {
            if (attributeName == null)
                throw new ArgumentNullException("attributeName", "attributeName cannot be null.");

            IList<CustomInstruction> setupMethodInstructions = new List<CustomInstruction>();

            var memberCollection = classType.Members;

            bool instructionsFound = false;

            foreach (var currentMember in memberCollection)
            {
                if (instructionsFound)
                    break;

                Method methodCandidate = currentMember as Method;

                if (methodCandidate != null)
                {
                    foreach (var attribute in methodCandidate.Attributes)
                    {
                        if (attribute.Type.ConstructorName.Name.ToUpper() == attributeName.ToUpper())
                        {
                            setupMethodInstructions = GetCustomInstructionListFromInstructionCollection(methodCandidate.Instructions);

                            instructionsFound = true;
                            break;
                        }
                    }
                }
            }

            return setupMethodInstructions;
        }


        /// <summary>
        /// Gets the type of the class that declares a given Member type.
        /// </summary>
        /// <param name="memberToQuery">
        /// The Member instance for which its class type is to be found.
        /// </param>
        /// <returns>
        /// The type of the class that declares the member instance.
        /// </returns>
        protected TypeNode GetDeclaringClassTypeFromMember(Member memberToQuery)
        {
            if (memberToQuery == null)
                throw new ArgumentNullException("memberToQuery", "memberToQuery cannot be null.");

            return memberToQuery.DeclaringType;
        }

        #endregion
    }
}

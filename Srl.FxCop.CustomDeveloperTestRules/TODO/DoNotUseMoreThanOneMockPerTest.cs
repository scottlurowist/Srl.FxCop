////
//// DoNotUseMoreThanOneMockPerTest.cs
////
//// Product: Total Payment Platform
////
//// Component: Srl.DeveloperTestRules
////
//// Description: Represents an FxCop rule that checks whether more than one
////              mocks is being used in a test method.
////              verified in the teardown method.
////
//// Author: Scott Lurowist
////
//// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
//// All rights reserved. Use of this software is governed by a license agreement. This 
//// software contains confidential, proprietary and trade secret information of Srl 
//// Corporation and/or one of its subsidiaries and is protected under United States and 
//// international copyright and other intellectual property laws.
////




//#region Using Directives

//using System.Collections.Generic;
//using Microsoft.FxCop.Sdk;

//#endregion




//namespace Srl.DeveloperTestRules
//{
//    /// <summary>
//    /// Represents an FxCop rule that checks whether more than one mocks is
//    /// being used in a test method.  verified in the teardown method.
//    /// </summary>
//    internal sealed class DoNotUseMoreThanOneMockPerTest : BaseDeveloperTestRule
//    {
//        #region Private Instance Fields

//        /// <summary>
//        /// A list of the instance fields for the test fixture class.
//        /// </summary>
//        private IList<string> _classInstanceFields = new List<string>();

//        /// <summary>
//        /// A list of fields that contain RhinoMocks generated mock instances.
//        /// </summary>
//        private IList<string> _fieldsThatContainMocks = new List<string>(); 

//        #endregion




//        /// <summary>
//        /// Initializes a new instance of DoNotUseMoreThanOneMock.
//        /// </summary>
//        public DoNotUseMoreThanOneMockPerTest() : base("DoNotUseMoreThanOneMockPerTest") {}


//        /// <summary>
//        /// Gets the visibility of targets for this rule.
//        /// </summary>
//        public override TargetVisibilities TargetVisibility
//        {
//            get { return TargetVisibilities.All; }
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="node"></param>
//        /// <returns></returns>
//        public override ProblemCollection Check(TypeNode node)
//        {
//            // We are only interested in classes.
//            if (node.NodeType != NodeType.Class)
//                return Problems;

//            // Find instance fields.
//            foreach (var member in node.Members)
//            {
//                if (member is Field)
//                {
//                    _classInstanceFields.Add(member.FullName);       
//                }
//            }

//            // Find setup methods and then look to see if those setup methods
//            // create mocks and assign them to instance fields.
//            foreach (var member in node.Members)
//            {
//                if (member is Method)
//                {
//                    foreach (var attribute in member.Attributes)
//                    {
//                        if (attribute.Type.ConstructorName.Name == "SetUpAttribute")
//                        {
//                            InstructionCollection coll = ((Method) member).Instructions;

//                            int instructionNumber = 0;

//                            foreach (var instruction in coll)
//                            {
//                                if ((instruction.OpCode == OpCode.Call) &&
//                                    (instruction.Value.ToString().StartsWith(RhinoMocksGenerateMock)))
//                                {
//                                    // Since we are in a setup method, the next instruction MUST BE a STFLD
//                                    // instruction to store the result of the call to GenerateMock in a
//                                    // field.
//                                    Instruction nextInstruction = coll[instructionNumber + 1];

//                                    string fieldName = ((Field) nextInstruction.Value).FullName;

//                                    // If the current field name exists in the list of class instance
//                                    // fields, then the current field is storing an instance of a mock
//                                    // and it will be used in test methods.
//                                    if (_classInstanceFields.Contains(fieldName))
//                                    {
//                                        _fieldsThatContainMocks.Add(fieldName);
//                                    }
//                                }

//                                instructionNumber++;
//                            }
//                        }
//                    }
//                }
//            }


//            // Now we can examine test methods now that we have checked fields and setup methods.
//            foreach (var member in node.Members)
//            {
//                if (member is Method)
//                {
//                    foreach (var attribute in member.Attributes)
//                    {
//                        if (attribute.Type.ConstructorName.Name == "TestAttribute")
//                        {
//                            int numberOfMocksInTestMethod = 0;

//                            InstructionCollection coll = ((Method)member).Instructions;

//                            int instructionNumber = 0;

//                            foreach (var instruction in coll)
//                            {
//                                // If we are using a field that contains a mock, then we must first
//                                // load the field (LDFLD) before we can invoke a method on the mock.
//                                if (instruction.OpCode == OpCode.Ldfld)
//                                {
//                                    if (_fieldsThatContainMocks.Contains(instruction.Value.ToString()))
//                                    {
//                                        numberOfMocksInTestMethod++;
//                                    }
//                                }

//                                if ((instruction.OpCode == OpCode.Call) &&
//                                    (instruction.Value.ToString().StartsWith(RhinoMocksGenerateMock)))
//                                {
//                                    numberOfMocksInTestMethod++;
//                                }
//                            }

//                            if (numberOfMocksInTestMethod > 1)
//                            {
//                                AddProblem();
//                            }
//                        }
//                    }
//                }
//            }

//            return Problems;
//        }


//        /// <summary>
//        /// Checks for methods that have the test attribute.
//        /// </summary>
//        /// <param name="member">
//        /// A possible instance of a member type node.
//        /// </param>
//        /// <returns>
//        /// A collection of introspection rule problems that contain instances
//        /// of test attributes on methods that use the var keyword.
//        /// </returns>
//        //public override ProblemCollection Check(Member member)
//        //{
//        //    // We are only checking methods.
//        //    if (!(member is Method))
//        //        return Problems;

//        //    AttributeNodeCollection attributes = member.Attributes;

//        //    if (attributes.Count > 0)
//        //        InspectAttributesForTestAttribute(attributes, member as Method);

//        //    return Problems;
//        //}


//        /// <summary>
//        /// Inspects a collection of attributes for the Test attribute and if 
//        /// found it checks that the return type of the test method is void.
//        /// If it is not void then a problem is created.s
//        /// </summary>
//        /// <param name="attributes">
//        /// The collection of attributes to be inspected.
//        /// </param>
//        /// <param name="methodToInspect">
//        /// The test method to inspect for the use of var.
//        /// </param>
//        //private void InspectAttributesForTestAttribute(AttributeNodeCollection attributes,
//        //                                               Method methodToInspect)
//        //{
//        //    foreach (AttributeNode attributeNode in attributes)
//        //    {
//        //        if (attributeNode.Type.ConstructorName.Name == "TestAttribute")
//        //        {
//        //            VisitStatements(methodToInspect.Body.Statements);
//        //        }
//        //    }
//        //}

//        //public override void VisitAssignmentStatement(AssignmentStatement assignment)
//        //public override void  VisitStatements(StatementCollection statements)
//        //{
//        //    int mockCount = 0;

//        //    foreach (var statement in statements)
//        //    {
//        //        if (!(statement is AssignmentStatement))
//        //            base.VisitStatements(statements);

//        //        if (statement is AssignmentStatement)
//        //        {
//        //            bool doesStatementCallRhinoMocksGenerateMock =
//        //                DoesAssignmentStatementCallToRhinoMocksGenerateMock(statement as AssignmentStatement);

//        //            if (doesStatementCallRhinoMocksGenerateMock)
//        //            {
//        //                mockCount++;
//        //            } 
//        //        }
//        //    }

//        //    if (mockCount > 1)
//        //    {
//        //        AddProblem();
//        //    }
//        //}
//    }
//}

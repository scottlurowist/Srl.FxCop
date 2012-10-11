//
// CoverageExludeUsage.cs
//
// Product: Total Payment Platform
//
// Component: Srl.DeveloperTestRules
//
// Description: Represents an FxCop rule that checks for the presence of the
//              CoverageExcludeUsage.
//
// Author: Scott Lurowist
//
// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
// All rights reserved. Use of this software is governed by a license agreement. This 
// software contains confidential, proprietary and trade secret information of Srl 
// Corporation and/or one of its subsidiaries and is protected under United States and 
// international copyright and other intellectual property laws.
//




//#region Using Directives

//using System;
//using Microsoft.FxCop.Sdk;

//#endregion




//namespace Srl.DeveloperTestRules
//{
//    /// <summary>
//    /// Represents an FxCop rule that checks for the presence of the
//    /// CoverageExcludeUsage.
//    /// </summary>
    //internal sealed class CoverageExcludeUsage : BaseDeveloperTestRule
    //{
    //    #region Private Const Values

    //    private const string CoverageExcludeAttributeName = "CoverageExcludeAttribute";

    //    #endregion




    //    /// <summary>
    //    /// Initializes a new instance of CoverageExcludeUsage.
    //    /// </summary>
    //    public CoverageExcludeUsage() : base("CoverageExcludeUsage") {}


    //    /// <summary>
    //    /// Gets the visibility of targets for this rule.
    //    /// </summary>
    //    public override TargetVisibilities TargetVisibility
    //    {
    //        get { return TargetVisibilities.All; }
    //    }


    //    /// <summary>
    //    /// Checks for [CoverageExclude] applied at the class level.
    //    /// </summary>
    //    /// <param name="type">
    //    /// A possible instance of a class type node.
    //    /// </param>
    //    /// <returns>
    //    /// A collection of introspection rule problems that contain instances
    //    /// of [CoverageExlude] attribute usage.
    //    /// </returns>
    //    public override ProblemCollection Check(TypeNode type)
    //    {
    //        //if (!(type.DeclaringType is ClassNode))
    //        //    return Problems;

    //        AttributeNodeCollection attributes = type.Attributes;

    //        if (attributes.Count > 0)
    //            InspectAttributesForCoverageExcludeAttribute(attributes);

    //        return Problems;
    //    }


    //    /// <summary>
    //    /// Checks for [CoverageExclude] applied at the method and property level.
    //    /// </summary>
    //    /// <param name="member">
    //    /// A possible instance of a member type node.
    //    /// </param>
    //    /// <returns>
    //    /// A collection of introspection rule problems that contain instances
    //    /// of [CoverageExlude] attribute usage.
    //    /// </returns>
    //    public override ProblemCollection Check(Member member)
    //    {
    //        AttributeNodeCollection attributes = member.Attributes;

    //        if (attributes.Count > 0)
    //            InspectAttributesForCoverageExcludeAttribute(attributes);

    //        return Problems;
    //    }


    //    /// <summary>
    //    /// Inspects a collection of attributes for the CoverageExclude
    //    /// attribute and adds them to the problems collection if one is 
    //    /// found.
    //    /// </summary>
    //    /// <param name="attributes">
    //    /// The collection of attributes to be inspected.
    //    /// </param>
    //    private void InspectAttributesForCoverageExcludeAttribute(AttributeNodeCollection attributes)
    //    {
    //        foreach (AttributeNode attributeNode in attributes)
    //        {
    //            if (attributeNode.Type.ConstructorName.Name == CoverageExcludeAttributeName)
    //            {
    //                AddProblem();
    //            }
    //        }           
    //    }
    //}
//}

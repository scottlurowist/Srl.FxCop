//
// CoverageExcludeOnMembersTarget.cs
//
// Product: Total Payment Platform
//
// Component: Srl.DeveloperTestRules
//
// Description: Represents a class where the CoverageExcludeAttribute
//              is set only at member levels.
//
// Author: Scott Lurowist
//
// Copyright © 2012 Srl Corporation and/or one of its subsidiaries.  
// All rights reserved. Use of this software is governed by a license agreement. This 
// software contains confidential, proprietary and trade secret information of Srl 
// Corporation and/or one of its subsidiaries and is protected under United States and 
// international copyright and other intellectual property laws.
//




#region Using Directives
#endregion




//namespace Srl.DeveloperTestRules.TestTarget
//{
//    /// <summary>
//    /// Represents a class where the CoverageExcludeAttribute
//    /// is set only at the class level.
//    /// </summary>
//    public class CoverageExcludeOnMembersTarget
//    {
//        /// <summary>
//        /// This method should not be flagged by the rule.
//        /// </summary>
//        public void MethodWithoutCoverageExcludeTarget()
//        {

//        }


//        /// <summary>
//        /// This method should be flagged by the rule.
//        /// </summary>
//        [CoverageExclude(ExclusionReason.ThirdPartyCode, ExclusionReasonDescription = "foo")]
//        public void MethodWithCoverageExcludeTarget()
//        {
//        }


//        /// <summary>
//        /// This property should not be flagged by the rule.
//        /// </summary>
//        public string PropertyWithoutCoverageExcludeTarget
//        {
//            get;
//            set;
//        }


//        /// <summary>
//        /// This property should be flagged by the rule.
//        /// </summary>
//        [CoverageExclude(ExclusionReason.ThirdPartyCode, ExclusionReasonDescription = "foo")]
//        public string PropertyWithCoverageExcludeTarget 
//        { 
//            get; 
//            set;
//        }


//        /// <summary>
//        /// This getter and setter should be flagged by the rule.
//        /// </summary>
//        public string PropertyWithCoverageExcludeOnGetterAndSetterTarget
//        {
//            [CoverageExclude(ExclusionReason.ThirdPartyCode, ExclusionReasonDescription = "foo")]
//            get;

//            [CoverageExclude(ExclusionReason.ThirdPartyCode, ExclusionReasonDescription = "foo")]
//            set;
//        }
//    }
//}
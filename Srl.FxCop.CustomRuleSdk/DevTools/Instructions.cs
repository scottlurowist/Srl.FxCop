//
// Instructions.cs
//
// Product:
//
// Component: Srl.FxCop.CustomRuleSdk
//
// Description: A tool that makes it easier to work with instructions at development. This code is not tested
//              and not robust and should not be used in rules that are deployed in an actual test environment.
//
// Author: Scott Lurowist
//




#region Using Directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion




namespace Srl.FxCop.CustomRuleSdk.DevTools
{
    /// <summary>
    /// A tool that makes it easier to work with instructions at development. This code is not tested
    /// and and not robust and should not be used in rules that are deployed in an actual test environment.
    /// </summary>
    public static class Instructions
    {
        /// <summary>
        /// Takes a list of CustomInstruction and writes it to a text file.
        /// </summary>
        /// <param name="instructionList">
        /// The list of CustomInstruction to be written to a text file.
        /// </param>
        /// <param name="filePath">
        /// the full path to the file to be written.
        /// </param>
        public static void WriteInstructionListForMethodToTextFile(
            IList<CustomInstruction> instructionList, string filePath)
        {
            File.WriteAllLines(filePath, instructionList.Select(x => x.ToString()).ToArray());
        }
    }
}
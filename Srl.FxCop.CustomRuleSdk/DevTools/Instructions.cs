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
using Microsoft.FxCop.Sdk;

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
            int instructionNumber = 0;

            File.WriteAllLines(filePath, instructionList.Select(x => ((instructionNumber++) + " - " + x.ToString())).ToArray());
        }


        /// <summary>
        /// Takes a list of CustomInstruction and generates C# code from these instructions. The generated code
        /// is used to create instruction lists for unit tests.
        /// </summary>
        /// <param name="instructionList">
        /// The list of CustomInstruction to be written to a text file.
        /// </param>
        /// <param name="filePath">
        /// the full path to the file to be written.
        /// </param>
        public static void GenerateCSharpCodeFromInstructionListForUnitTests(
            IList<CustomInstruction> instructionList, string filePath)
        {
            int instructionNumber = 1;

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("IList<CustomInstruction> instructionList = new List<CustomInstruction>();");
                writer.WriteLine();
                writer.WriteLine("CustomInstruction instruction;");
                writer.WriteLine("CustomMethod meth;");
                writer.WriteLine("CustomLocal custLocal;");
                writer.WriteLine();

                foreach (var instruction in instructionList)
                {
                    writer.WriteLine("// CIL Instruction {0}.", instructionNumber);
                    writer.WriteLine("instruction = new CustomInstruction();");
                    writer.WriteLine("instruction.Offset = {0};", instruction.Offset);
                    writer.WriteLine("instruction.OpCode = OpCode.{0};", instruction.OpCode.ToString());

                    if (instruction.Value == null)
                    {
                        writer.WriteLine("instruction.Value = null;");
                    }
                    else if (instruction.Value is CustomMethod)
                    {
                        var meth = instruction.Value as CustomMethod;

                        writer.WriteLine("meth = new CustomMethod();");
                        writer.WriteLine("meth.IsReturnTypeVoid = {0};", meth.IsReturnTypeVoid ? "true" : "false");
                        writer.WriteLine("meth.IsStatic = {0};", meth.IsStatic ? "true" : "false");
                        writer.WriteLine("meth.NumberOfParameters = {0};", meth.NumberOfParameters);
                        writer.WriteLine("meth.Signature = \"{" + meth.Signature + "}\";");
                        writer.WriteLine("instruction.Value = meth;");
                    }
                    //else if (instruction.Value is CustomParameterCollection)
                    //{
                    //    writer.WriteLine("parameters = new CustomParameterCollection();");
                    //    writer.WriteLine("parameters.Count = (currentInstruction.Value as ParameterCollection).Count;");
                    //    writer.WriteLine("currentInstruction.Value = parameters;");
                    //}
                    else if (instruction.Value is ValueType)
                    {
                        writer.WriteLine("instruction.Value = " + instruction.Value + ";");
                    }
                    else if (instruction.Value is CustomLocal)
                    {
                        var custLocal = instruction.Value as CustomLocal;

                        writer.WriteLine("custLocal = new CustomLocal();");
                        writer.WriteLine("custLocal.Name = \"{0}\";", custLocal.Name);
                        writer.WriteLine("instruction.Value = custLocal;");                        
                    }
                    else
                    {
                        writer.WriteLine("instruction.Value = \"{" + instruction.Value + "}\";");
                    }

                    writer.WriteLine();
                    writer.WriteLine("instructionList.Add(instruction);");
                    writer.WriteLine();
                    
                    instructionNumber++;
                }

                writer.Write("return instructionList;");
            }            
        }
    }
}
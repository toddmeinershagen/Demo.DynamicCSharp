using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public class AssemblyProvider : IAssemblyProvider
    {
        public Assembly GetAssemblyFor(string source)
        {
            var providerOptions = new Dictionary<string, string>
            {
                {"CompilerVersion", "v4.0"}
            };
            var provider = new CSharpCodeProvider(providerOptions);

            var parameters = new CompilerParameters
            {
                GenerateInMemory = true,
                GenerateExecutable = false
            };

            var result = provider.CompileAssemblyFromSource(parameters, source);

            if (result.Errors.HasErrors)
            {
                var errorString = FormatErrors(result.Errors);
                throw new Exception($"Compilation failed.  {errorString}");
            }

            return result.CompiledAssembly;
        }

        private static string FormatErrors(CompilerErrorCollection errors)
        {
            var builder = new StringBuilder();
            for (var index = 0; index < errors.Count; index++)
            {
                var error = errors[index];
                builder.Append($"\"{error.ErrorText}\" (line {error.Line})  ");
            }

            return builder.ToString();
        }
    }
}
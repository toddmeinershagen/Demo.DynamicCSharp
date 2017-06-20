using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Demo.DynamicCSharp.CommandLine
{
    public static class AssemblyExtensions
    {
        public static void Execute(this Assembly assembly, string typeName, string methodName, params object[] parameters)
        {
            var type = assembly.CreateInstance(typeName);

            if (type == null)
            {
                throw new ArgumentException($"The '{typeName}' type does not exist.", nameof(typeName));
            }

            var method = type?.GetType().GetMethod(methodName);

            if (method == null)
            {
                throw new ArgumentException($"The '{methodName}' method does not exist.", nameof(methodName));
            }

            var methodParameters = method.GetParameters();
            for (var index = 0; index < methodParameters.Length; index++)
            {
                var methodParameter = methodParameters[index];
                if (parameters[index].GetType() != methodParameter.ParameterType)
                {
                    var incoming = string.Join(", ", parameters.Select(p => p.GetType().FullName));
                    var expected = string.Join(", ", methodParameters.Select(p => p.ParameterType.FullName));
                    var message = $"The input parameters do not match the signature of the method.\r\nIncoming:  {incoming}\r\nExpected:  {expected}";

                    throw new ArgumentException(message);
                }
            }

            method.Invoke(type, parameters);
        }
    }
}
using System;
using System.Reflection;

namespace Demo.DynamicCSharp.CommandLine
{
    public static class AssemblyExtensions
    {
        public static void Execute(this Assembly assembly, string typeName, string methodName, object[] parameters)
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

            method.Invoke(type, parameters);
        }
    }
}
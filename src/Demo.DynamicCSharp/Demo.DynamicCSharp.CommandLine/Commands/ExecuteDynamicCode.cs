using System;
using Demo.DynamicCSharp.CommandLine.Providers;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class ExecuteDynamicCode : ICommand
    {
        private readonly IAssemblyProvider _assemblyProvider;
        private readonly ISourceProvider _sourceProvider;
        private readonly Guid _sourceId;
        private readonly string _typeName;

        public ExecuteDynamicCode(IAssemblyProvider assemblyAssemblyProvider, ISourceProvider sourceProvider, Guid sourceId, string typeName)
        {
            _assemblyProvider = assemblyAssemblyProvider;
            _sourceProvider = sourceProvider;
            _sourceId = sourceId;
            _typeName = typeName;
        }

        public void Execute(Input input)
        {
            var source = _sourceProvider.GetSourceFor(_sourceId.ToString());
            var assembly = _assemblyProvider.GetAssemblyFor(source);

            assembly.Execute(_typeName, "Execute", input);
        }
    }
}
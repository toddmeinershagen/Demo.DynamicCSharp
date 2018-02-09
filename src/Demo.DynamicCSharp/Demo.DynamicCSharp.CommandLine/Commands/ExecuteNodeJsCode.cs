using System;
using System.Threading.Tasks;
using Demo.DynamicCSharp.CommandLine.Providers;
using EdgeJs;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class ExecuteNodeJsCode : ICommand
    {
        private readonly ISourceProvider _sourceProvider;
        private readonly Guid _sourceId;

        public ExecuteNodeJsCode(ISourceProvider sourceProvider, Guid sourceId)
        {
            _sourceProvider = sourceProvider;
            _sourceId = sourceId;
        }

        public async Task Execute(Input input)
        {
            var script = await _sourceProvider.GetSourceFor(_sourceId.ToString());
            var func = Edge.Func(script);

            await func(input);
        }
    }
}
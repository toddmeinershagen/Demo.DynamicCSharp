using System;
using System.Linq;
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
            try
            {
                var script = await _sourceProvider.GetSourceFor(_sourceId.ToString());
                var func = Edge.Func(script);

                await func(input);
            }
            catch (Exception ex)
            {
                throw GetException(ex);
            }
        }

        private Exception GetException(Exception ex)
        {
            var errorType = ex.InnerException.Message.Split(':').FirstOrDefault();
            if (errorType == "BadRequestError")
            {
                return new BadRequestException(ex.InnerException.Message);
            }

            return ex;
        }
    }

    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        { }
    }
}
using System;
using System.Threading.Tasks;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class ExecuteStaticCode : ICommand
    {
        public async Task Execute(Input input)
        {
            await Console.Out.WriteLineAsync("Hello, world.");
        }
    }
}
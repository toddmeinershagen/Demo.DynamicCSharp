using System;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class ExecuteStaticCode : ICommand
    {
        public void Execute(Input input)
        {
            Console.WriteLine("Hello, world.");
        }
    }
}
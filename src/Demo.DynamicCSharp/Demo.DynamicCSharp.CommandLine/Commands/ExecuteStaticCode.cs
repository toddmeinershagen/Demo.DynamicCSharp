using System;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class ExecuteStaticCode : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Hello, world.");
        }
    }
}
namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public interface ICommand
    {
        void Execute(Input input);
    }
}
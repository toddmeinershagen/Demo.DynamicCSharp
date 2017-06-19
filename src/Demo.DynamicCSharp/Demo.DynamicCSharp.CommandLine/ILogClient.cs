namespace Demo.DynamicCSharp.CommandLine
{
    public interface ILogClient
    {
        void Error(string message, params object[] args);
    }
}
namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public interface ISourceProvider
    {
        string GetSourceFor(string sourceId);
    }
}
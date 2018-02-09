using System.Threading.Tasks;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public interface ISourceProvider
    {
        Task<string> GetSourceFor(string sourceId);
    }
}
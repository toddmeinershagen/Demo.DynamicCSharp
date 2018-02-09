using System;
using System.IO;
using System.Threading.Tasks;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public class FileSourceProvider : ISourceProvider
    {
        public async Task<string> GetSourceFor(string sourceId)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Source", $"source-{sourceId}.txt");
            return await Task.FromResult(File.ReadAllText(path));
        }
    }
}
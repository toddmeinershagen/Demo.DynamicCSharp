using System;
using System.IO;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public class FileSourceProvider : ISourceProvider
    {
        public string GetSourceFor(string sourceId)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "Source", $"source-{sourceId}.txt");
            return File.ReadAllText(path);
        }
    }
}
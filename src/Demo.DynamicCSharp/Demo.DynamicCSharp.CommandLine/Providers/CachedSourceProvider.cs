using System;
using Common.Caching;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public class CachedSourceProvider : ISourceProvider
    {
        private readonly ISourceProvider _provider;
        private static readonly ICache Cache = new InMemoryCache();

        public CachedSourceProvider(ISourceProvider provider)
        {
            this._provider = provider;
            _provider = provider;
        }

        public string GetSourceFor(string sourceId)
        {
            return Cache.GetOrAdd(sourceId, () => _provider.GetSourceFor(sourceId), DateTimeOffset.MaxValue);
        }
    }
}
using System;
using System.Threading.Tasks;
using CommonGround.Caching;

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

        public async Task<string> GetSourceFor(string sourceId)
        {
            return await Cache.GetOrAdd(sourceId, () => _provider.GetSourceFor(sourceId), DateTimeOffset.MaxValue);
        }
    }
}
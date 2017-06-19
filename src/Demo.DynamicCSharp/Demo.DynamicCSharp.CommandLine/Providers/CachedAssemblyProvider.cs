using System;
using System.Reflection;
using Common.Caching;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public class CachedAssemblyProvider : IAssemblyProvider
    {
        private static readonly ICache Cache = new InMemoryCache();
        private readonly IAssemblyProvider _provider;

        public CachedAssemblyProvider(IAssemblyProvider provider)
        {
            _provider = provider;
        }

        public Assembly GetAssemblyFor(string source)
        {
            var assemblyId = source.GetHashCode().ToString();
            return Cache.GetOrAdd(assemblyId, () => _provider.GetAssemblyFor(source), DateTimeOffset.MaxValue);
        }
    }
}
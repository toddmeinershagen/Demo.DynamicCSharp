using System.Reflection;

namespace Demo.DynamicCSharp.CommandLine.Providers
{
    public interface IAssemblyProvider
    {
        Assembly GetAssemblyFor(string source);
    }
}
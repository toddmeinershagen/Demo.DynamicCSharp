using System.Threading.Tasks;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public interface ICommand
    {
        Task Execute(Input input);
    }
}
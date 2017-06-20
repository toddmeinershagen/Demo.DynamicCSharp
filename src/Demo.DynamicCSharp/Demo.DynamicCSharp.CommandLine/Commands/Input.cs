using System.Security;

namespace Demo.DynamicCSharp.CommandLine.Commands
{
    public class Input
    {
        public string Username { get; set; }
        public SecureString Password { get; set; }
    }
}

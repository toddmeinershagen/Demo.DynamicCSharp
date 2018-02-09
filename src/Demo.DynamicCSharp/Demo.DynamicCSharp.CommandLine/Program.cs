using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using Demo.DynamicCSharp.CommandLine.Commands;
using Demo.DynamicCSharp.CommandLine.Providers;

namespace Demo.DynamicCSharp.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            var logClient = new LogClient();

            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine($"====Run{i:00}====");

                var assemblyProvider = new CachedAssemblyProvider(new AssemblyProvider());
                var sourceProvider = new CachedSourceProvider(new FileSourceProvider());

                var commands = new List<ICommand>
                {
                    new ExecuteStaticCode(),
                    new ExecuteDynamicCode(assemblyProvider, sourceProvider, new Guid("01511bc9-ec98-4051-90c3-9a16f033befb"), "Type1"),
                    new ExecuteDynamicCode(assemblyProvider, sourceProvider, new Guid("d6b39937-2150-487a-9dbe-f46fb980f335"), "Type2"),
                    new ExecuteDynamicCode(assemblyProvider, sourceProvider, new Guid("74b57f30-c703-45a2-afec-84c9824f4e51"), "Type3"),
                    new ExecuteDynamicCode(assemblyProvider, sourceProvider, new Guid("9fa78c61-716a-4123-b75e-e86e89e03413"), "Type4"),
                    new ExecuteNodeJsCode(sourceProvider, new Guid("d6b39937-2150-487a-9dbe-f46fb980f336"))
                };

                foreach (var command in commands)
                {
                    var username = Guid.NewGuid().ToString();
                    var password = new SecureString();
                    foreach (var c in Guid.NewGuid().ToString().ToCharArray())
                    {
                        password.AppendChar(c);
                    }

                    var watch = Stopwatch.StartNew();

                    try
                    {
                        command.Execute(new Input{Username = username, Password = password});
                    }
                    catch (Exception ex)
                    {
                        logClient.Error(ex.Message);
                    }
                    finally
                    {
                        watch.Stop();
                        Console.WriteLine($"{command.GetType().Name}:  {watch.ElapsedMilliseconds} ms.");
                    }
                }

                Console.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}

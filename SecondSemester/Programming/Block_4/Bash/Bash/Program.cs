using System;
using System.Diagnostics;
using Bash.Bash;
namespace Bash
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logger = new BashOutput.Logger();
            var bash = new MyBash(logger);

            var commandParser = new CommandParser();
            while (true)
            {
                commandParser.Connectors.Clear();
                commandParser.Commands.Clear();
                bash.RunCommand(commandParser);
            }
            Console.WriteLine();
        }
    }
}

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

            while (true)
            {
                bash.RunCommand();
            }
            Console.WriteLine();
        }
    }
}

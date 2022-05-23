using System;
using System.IO;

namespace Bash.BashOutput
{
    public class Logger
    {
        public string ReadCommand()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Directory:" + Directory.GetCurrentDirectory() + "$ ");
            return Console.ReadLine();
        }

        public void PrintCommandResult(string[] result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(var item in result)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void PrintCommandResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(result);
        }
    }
}

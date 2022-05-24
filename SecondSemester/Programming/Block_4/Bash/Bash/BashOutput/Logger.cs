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

            var counter = 1;
            foreach(var item in result)
            {
                if (result.Length == counter)
                {
                    Console.Write(item.Substring(0, item.Length - 1));
                }
                else
                {
                    Console.Write(item);
                }
                counter++;
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

using System;
using System.IO;
using Bash.Bash;

namespace Bash.BashOutput
{
    // Логгер нужен для того, чтобы считывать команды и выводить результат их работы в консоль.
    public class Logger 
    {
        // Переменная, содержащая вывод в консоль последней команды. Нужна, в первую очередь, для Unit-тестов
        // (сравнивать то, что было выведено в консоль, с тем, что должно получаться на самом деле).
        public string lastConsoleWrite = "";

        public string ReadCommand()
        {
            Console.ForegroundColor = ConsoleColor.White;

            lastConsoleWrite = "";

            Console.Write("Directory:" + Directory.GetCurrentDirectory() + "$ ");

            var answer = Console.ReadLine();

            // Если введено слово скрипт, то создаем объект от класса ScriptExecuter, метод Run которого просто возвращает строку,
            // состоящую из команд. Как будто пользователь сам ввел все то, что в файле. Однако на деле он просто указывает путь к файлу.
            if (answer.Equals("script")) 
            {
                var scriptExecuter = new ScriptExecuter();

                Console.WriteLine("Enter path:");

                var path = Console.ReadLine();
                var script = scriptExecuter.Run(path);
                return script;
            }

            // Иначе просто работаем со строкой, введенной пользователем.
            else
            {
                return answer;
            }
        }

        // Ниже представлены методы, печатающие результат работы команды, введенной пользователем.
        public void PrintCommandResult(string[] result)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            var counter = 1;
            foreach(var item in result)
            {
                // Удаление последнего пробела.
                // Просто особенность сложностей работы с парсом строк.
                // Воспринимать как обычный вывод всех элементов массива result.
                if (result.Length == counter) 
                {
                    lastConsoleWrite += item.Substring(0, item.Length -1);
                    Console.Write(item.Substring(0, item.Length - 1));
                }
                else
                {
                    lastConsoleWrite += item;
                    Console.Write(item);
                }
                counter++;
            }

            lastConsoleWrite += '\n';
            Console.WriteLine();
        }

        public void PrintCommandResult(string result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            lastConsoleWrite += result + '\n';
            Console.WriteLine(result);
        }
    }
}

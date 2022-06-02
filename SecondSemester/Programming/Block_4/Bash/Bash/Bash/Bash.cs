using System;
using System.Collections.Generic;
using Bash.BashOutput;
using Bash.Commands;

namespace Bash.Bash
{
    public class MyBash
    {
        LocalVariables localVariables = new LocalVariables(); // Локальные переменные сессии.

        private Logger _logger; // Логгер для вывода в консоль.

        public MyBash(Logger logger)
        {
            _logger = logger;
        }

        public void RunCommand(CommandParser commandParser, string command)
        {
            // В методе Main всегда передаем пустую строку, а значит команда всегда будет считываться с помощью логгера.
            // Тем не менее, данная проверка и передача параметра command нужна для упрощенных Unit-тестов.
            // В них мы передаем в метод RunCommand какую-то команду, тем самым не принимая ввод пользователя с консоли.
            if (command.Equals(""))
            {
                command = _logger.ReadCommand();
            }

            // Подставляем локальные переменные в строку команды.
            var atCommand = new AtCommand();
            command = atCommand.Run(command, localVariables);

            // Далее парсим команду.
            commandParser.ParseCommand(command);

            // Перебираем каждую команду.
            var counter = 0;
            foreach (var item in commandParser.Commands)
            {

                // Особенности работы со строками: избавляемся от первых пробелов, введенных пользователем.
                var i = 0;
                if (item.Length != 0)
                {
                    while (item.Split()[i] == "")
                    {
                        i++;
                        if (item.Length == i)
                        {
                            break;
                        }
                    }
                }

                // Далее берем из строки первое "слово" -- это наша команда.
                var currCommand = item.Split()[i];

                // Все остальные "слова" -- аргументы нашей команды.
                var splittedArgs = item.Substring(currCommand.Length + i).Split();

                // Особенности работы со строками: избавляемся от пробелов.
                var args = new List<string>();
                foreach (var element in splittedArgs)
                {
                    if (element != "")
                    {
                        args.Add(element);
                    }
                }

                // Если это первая команда, то просто выполняем ее.
                // Если же нет, все зависит от последнего результата и коннектора, связывающего предыдущую и текущую команду.
                // Выполняем.
                if (counter == 0)
                {
                    commandParser.lastResult = CommandExecuter.ExecuteCommand(currCommand, args.ToArray(), _logger, localVariables, commandParser, this);
                }
                else if (commandParser.Connectors[counter - 1 ] == ';' || (commandParser.Connectors[counter - 1] == '&'
                    && Convert.ToBoolean(commandParser.lastResult) == false) || (commandParser.Connectors[counter - 1] == '|'
                    && Convert.ToBoolean(commandParser.lastResult) == true))
                {
                    commandParser.lastResult = CommandExecuter.ExecuteCommand(currCommand, args.ToArray(), _logger, localVariables, commandParser, this);
                }
                counter++;
            }
            Console.WriteLine();
        }
    }
}

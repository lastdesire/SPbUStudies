using System;
using System.Collections.Generic;
using Bash.BashOutput;
using Bash.Commands;

namespace Bash.Bash
{
    public class MyBash
    {
        private Logger _logger;

        public MyBash(Logger logger)
        {
            _logger = logger;
        }

        public void RunCommand()
        {
            var command = _logger.ReadCommand();

            var commandParser = new CommandParser();
            commandParser.ParseCommand(command);

            var counter = 0;
            foreach (var item in commandParser.Commands)
            {
                var i = 0;
                if (item.Length != 0)
                {
                    while (item.Split()[i] == "")
                    {
                        i++;
                        if(item.Length == i)
                        {
                            break;
                        }
                    }
                }
                var currCommand = item.Split()[i];

                var splittedArgs = item.Substring(currCommand.Length + i).Split();
                var args = new List<string>();
                foreach(var element in splittedArgs)
                {
                    if (element != "")
                    {
                        args.Add(element);
                    }
                }
                if (counter == 0)
                {
                    commandParser.lastResult = CommandExecuter.ExecuteCommand(currCommand, args.ToArray(), _logger);
                }
                else if (commandParser.Connectors[counter - 1 ] == ';' || (commandParser.Connectors[counter - 1] == '&'
                    && commandParser.lastResult == true) || (commandParser.Connectors[counter - 1] == '|'
                    && commandParser.lastResult == false))
                {
                    commandParser.lastResult = CommandExecuter.ExecuteCommand(currCommand, args.ToArray(), _logger);
                }
                counter++;
            }
            Console.WriteLine();
        }
    }
}

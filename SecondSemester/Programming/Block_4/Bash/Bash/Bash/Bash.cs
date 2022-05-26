using System;
using System.Collections.Generic;
using System.Text;
using Bash.BashOutput;
using Bash.Commands;
using System.Collections;

namespace Bash.Bash
{
    public class MyBash
    {
        LocalVariables localVariables = new LocalVariables();

        private Logger _logger;

        public MyBash(Logger logger)
        {
            _logger = logger;
        }

        public void RunCommand(CommandParser commandParser, string command)
        {
            if (command.Equals(""))
            {
                command = _logger.ReadCommand();
            }

            var atCommand = new AtCommand();
            command = atCommand.Run(command, localVariables);

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
                        if (item.Length == i)
                        {
                            break;
                        }
                    }
                }
                var currCommand = item.Split()[i];

                var splittedArgs = item.Substring(currCommand.Length + i).Split();

                var args = new List<string>();
                foreach (var element in splittedArgs)
                {
                    if (element != "")
                    {
                        args.Add(element);
                    }
                }

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

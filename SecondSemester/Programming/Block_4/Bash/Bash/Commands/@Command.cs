using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bash.Bash;

namespace Bash.Commands
{
    public class AtCommand
    {
        public string Name { get; protected set; } = "@";

        public string Run(string command, LocalVariables localVariables)
        {
            for (var c = 0; c < command.Length; c++)
            {
                if (command[c] == '@')
                {
                    var start = c;
                    var variable = new StringBuilder();
                    while (c != ' ' && c < command.Length - 1)
                    {
                        c++;
                        variable.Append(command[c]);
                    }
                    var end = c + 1;

                    if (localVariables.localVariables.Contains(variable.ToString()))
                    {
                        command = command.Substring(0, start) + localVariables.localVariables[variable.ToString()].ToString() + command.Substring(end);
                    }
                    variable.Clear();
                }

            }
            return command;
        }

    }
}

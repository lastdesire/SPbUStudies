using System;
using System.Collections.Generic;
using System.Text;

namespace Bash.Bash
{
    // For example: echo 1 2 3 echo 4; echo 5
    // Result: 1 2 3 echo 4
    //         5
    // Commands = ["echo 1 2 3 echo 4", "echo 5"]
    // CommandsResult = [true, true]
    // Connectors = [";"]
    public class CommandParser
    {
        public List<string> Commands;
        public int lastResult;
        public string[] lastWrite;
        public List<char> Connectors;

        public CommandParser()
        {
            Commands = new List<string>();
            Connectors = new List<char>();
            lastResult = 0;
            lastWrite = Array.Empty<string>();
        }



        public void ParseCommand(string commands)
        {
            var command = new StringBuilder();
            foreach (var item in commands)
            {
                if (item == '~')
                {
                    var strLastResult = lastResult.ToString();
                    var len = strLastResult.Length;
                    for(var i = 0; i < len; i++)
                    {
                        command.Append(strLastResult[i]);
                    }
                }
                else if (item == ';' || item == '&' || item == '|')
                {
                    Commands.Add(command.ToString());
                    command.Length = 0;
                    Connectors.Add(item);
                }
                else if (item == '>' || item == '\'')
                {
                    Commands.Add(command.ToString());
                    command.Clear();
                    command.Append(item);
                    Connectors.Add('&');
                }
                else
                {
                    command.Append(item);
                }
            }
            Commands.Add(command.ToString());
            command.Clear();
        }
    }
}

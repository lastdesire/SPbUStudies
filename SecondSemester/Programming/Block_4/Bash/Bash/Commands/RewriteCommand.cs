using System;
using System.Collections.Generic;
using System.IO;
using Bash.Bash;

namespace Bash.Commands
{

    public class RewriteCommand
    {
        public string Name { get; protected set; } = ">";

        public string[] Run(string[] args, CommandParser commandParser)
        {
            List<string> result = new List<string>();
            
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    var file = new StreamWriter(args[i]);
                    for (var j = 0; j < commandParser.lastWrite.Length; j++)
                    {
                        file.Write(commandParser.lastWrite[j]);
                    }
                    file.Dispose();
                }
                catch (Exception)
                {
                    result.Add("No such file or directory ");
                }
            }
            return result.ToArray();
        }

    }
}

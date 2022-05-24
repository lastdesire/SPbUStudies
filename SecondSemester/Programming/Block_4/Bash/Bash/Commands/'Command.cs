﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Bash.Bash;

namespace Bash.Commands
{

    public class WriteCommand
    {
        public string Name { get; protected set; } = "'";

        public string[] Run(string[] args, CommandParser commandParser)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    var fileRead = new StreamReader(args[i]);
                    var savedText = fileRead.ReadToEnd();
                    fileRead.Dispose();
                    var file = new StreamWriter(args[i]);
                    file.Write(savedText);
                    for (var j = 0; j < commandParser.lastWrite.Length; j++)
                    {
                        file.Write(commandParser.lastWrite[j]);
                    }
                    file.Write('\n');
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

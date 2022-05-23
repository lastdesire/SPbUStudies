using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class PwdCommand : Command
    {
        public PwdCommand()
        {
            Name = "pwd";
        }

        public override string[] Run(string[] args)
        {
            var result = new List<string>();

            var currPath = Directory.GetCurrentDirectory();
            var pathInfo = new DirectoryInfo(currPath);

            result.Add(currPath);
            foreach (var file in pathInfo.EnumerateFiles())
            {
                result.Add(file.Name);
            }

            return result.ToArray();
        }
    }
}

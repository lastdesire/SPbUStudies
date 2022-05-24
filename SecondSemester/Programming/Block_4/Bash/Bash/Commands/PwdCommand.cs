using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class PwdCommand : Command
    {
        public override string Name { get; protected set; } = "pwd";

        public override string[] Run(string[] args)
        {
            var result = new List<string>();

            var currPath = Directory.GetCurrentDirectory();
            var pathInfo = new DirectoryInfo(currPath);

            result.Add(currPath);
            foreach (var file in pathInfo.EnumerateFiles())
            {
                result.Add(file.Name + '\n');
            }

            return result.ToArray();
        }
    }
}

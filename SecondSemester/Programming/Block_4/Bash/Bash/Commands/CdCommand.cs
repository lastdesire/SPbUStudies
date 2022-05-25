using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class CdCommand : Command
    {
        public override string Name { get; protected set; } = "cd";

        public override string[] Run(string[] args)
        {
            var result = new List<string>();
            try
            {
                var path = args[0];
                Directory.SetCurrentDirectory(path);
                result.Add("Done ");
            }
            catch(Exception)
            {
                result.Add("No correct directory ");
            }
            return result.ToArray();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class CatCommand : Command
    {
        public override string Name { get; protected set; } = "cat";

        public override string[] Run(string[] args)
        {
            var result = new List<string>();
            foreach (var path in args)
            {
                try
                {
                    var text = File.ReadAllText(path);
                    result.Add(text);

                }
                catch (Exception)
                {
                    result.Add("No such file or directory\n");
                }
            }

            return result.ToArray();
            
        }

    }
}

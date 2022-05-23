using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class EchoCommand : Command
    {
        public EchoCommand()
        {
            Name = "echo";
        }

        public override string[] Run(string[] args)
        {
            var result = new List<string>();

            foreach (var item in args)
            {
                var array = item.Split();
                foreach(var element in array)
                {
                    if (element != "")
                    {
                        result.Add(element);
                    }
                }
            }

            return result.ToArray();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bash.Commands;

namespace Bash.Bash
{
    public class ScriptExecuter
    {
        public string Name { get; protected set; } = "script";


        public string Run(string path)
        {
            var result = new StringBuilder();
            try
            {
                var fileRead = new StreamReader(path);
                var script = fileRead.ReadToEnd();
                for (var i = 0; i < script.Split("\n").Length; i++)
                {
                    result.Append(script.Split("\n")[i]);
                }
            }
            catch (Exception)
            {
                result.Append("No such file or directory to script ");
            }
            return result.ToString();
        }
    }
}

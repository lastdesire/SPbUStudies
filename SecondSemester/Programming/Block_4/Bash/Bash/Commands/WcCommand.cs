using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bash.Commands
{
    public class WcCommand : Command
    {
        public override string Name { get; protected set; } = "wc";

        public override string[] Run(string[] args)
        {
            var result = new List<string>();

			for (int i = 0; i < args.Length; i++)
			{
				if (i != 0)
                {
					result.Add("\n");
                }
				try
				{
					var text = new StringBuilder(File.ReadAllText(args[i]));

					var linesCounter = 0;
					var wordsCounter = text.ToString().Split(" ").Length;
					var bytesCounter = new FileInfo(args[i]).Length;

					for (var ch = 0; ch < text.Length; ch++)
                    {
						if (text[ch] == '\n')
                        {
							linesCounter++;
                        }
                    }
					result.Add($"{linesCounter}" + $" {wordsCounter}" + $" {bytesCounter} ");
					
				}
				catch
				{
					result.Add("No such file or directory ");
				}
				
			}
			return result.ToArray();
		}

    }
}

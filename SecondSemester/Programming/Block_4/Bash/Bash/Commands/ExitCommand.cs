using System;
using System.Collections.Generic;
using System.IO;
namespace Bash.Commands
{
    public class ExitCommand
    {
        public string Name { get; protected set; } = "exit";

        public void Run()
        {
            Environment.Exit(0);
        }

    }
}

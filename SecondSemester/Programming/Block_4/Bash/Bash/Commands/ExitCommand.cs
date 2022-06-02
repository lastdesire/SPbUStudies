using System;

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

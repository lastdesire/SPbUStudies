using System;
using Bash.BashOutput;
using Bash.Commands;

namespace Bash.Bash
{
    public static class CommandExecuter
    {
        public static bool ExecuteCommand(string currCommand, string[] args, Logger logger)
        {
            var isSuccess = false;
            switch (currCommand)
            {
                case "pwd":
                    var pwdCommand = new PwdCommand();
                    logger.PrintCommandResult(pwdCommand.Run(args));
                    isSuccess = true;
                    break;
                case "echo":
                    var echoCommand = new EchoCommand();
                    logger.PrintCommandResult(echoCommand.Run(args));
                    isSuccess = true;
                    break;
                default:
                    logger.PrintCommandResult($"There is no command \"{currCommand}\"");
                    break;
            }
            return isSuccess;
        }
    }
}

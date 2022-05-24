using System;
using Bash.BashOutput;
using Bash.Commands;

namespace Bash.Bash
{
    public static class CommandExecuter
    {
        public static int ExecuteCommand(string currCommand, string[] args, Logger logger, LocalVariables localVariables, CommandParser commandParser)
        {
            int newLastResult;
            switch (currCommand)
            {
                case "pwd":
                    var pwdCommand = new PwdCommand();
                    commandParser.lastWrite = new string[pwdCommand.Run(args).Length];
                    pwdCommand.Run(args).CopyTo(commandParser.lastWrite, 0);
                    logger.PrintCommandResult(pwdCommand.Run(args));
                    newLastResult = 0;
                    break;
                case "echo":
                    var echoCommand = new EchoCommand();
                    commandParser.lastWrite = new string[echoCommand.Run(args).Length];
                    echoCommand.Run(args).CopyTo(commandParser.lastWrite, 0);
                    logger.PrintCommandResult(echoCommand.Run(args));
                    newLastResult = 0;
                    break;
                case "cat":
                    var catCommand = new CatCommand();
                    commandParser.lastWrite = new string[catCommand.Run(args).Length];
                    catCommand.Run(args).CopyTo(commandParser.lastWrite, 0);
                    logger.PrintCommandResult(catCommand.Run(args));
                    newLastResult = 0;
                    break;
                case "true":
                    newLastResult = 0;
                    break;
                case "false":
                    newLastResult = 1;
                    break;
                case "$":
                    var dollarCommand = new DollarCommand();
                    var result = dollarCommand.Run(args, localVariables);
                    if (result[0] == "There is no command \"$\"" || result[0] == "You can't add variables with first integer char")
                    {
            
                        logger.PrintCommandResult(result[0]);
                        newLastResult = 1;
                    }
                    else
                    {
                        newLastResult = 0;
                    }
                    break;
                case "wc":
                    var wcCommand = new WcCommand();
                    commandParser.lastWrite = new string[wcCommand.Run(args).Length];
                    wcCommand.Run(args).CopyTo(commandParser.lastWrite, 0);
                    logger.PrintCommandResult(wcCommand.Run(args));
                    newLastResult = 0;
                    break;
                case ">":
                    var rewriteCommand = new RewriteCommand();
                    logger.PrintCommandResult(rewriteCommand.Run(args, commandParser));
                    newLastResult = 0;
                    break;
                case "'":
                    var writeCommand = new WriteCommand();
                    logger.PrintCommandResult(writeCommand.Run(args, commandParser));
                    newLastResult = 0;
                    break;
                default:
                    logger.PrintCommandResult($"There is no command \"{currCommand}\"");
                    newLastResult = 127;
                    break;
            }
            return newLastResult;
        }
    }
}

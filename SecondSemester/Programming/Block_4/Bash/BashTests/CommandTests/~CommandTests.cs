using System;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class TildaCommandTests
    {
        // Tilda on this bashAnalog works on last entered command earlier.
        // So, if qwe; echo ~ => 0, because last entered command (nothing) was okay.
        // Also if bash found command, tilda would be 0, despite is command okay or not.
        [Test]
        public void CheckTildaFirstTime()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "echo ~";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("0\n", logger.lastConsoleWrite);
        }

        [Test]
        public void CheckTildaAfterOkayCommand()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "echo 5; echo ~";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5\n0\n", logger.lastConsoleWrite);
        }

        [Test]
        public void CheckTildaAfterNoOkayCommand()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "qwe";
            bash.RunCommand(commandParser, command);
            command = "echo ~";
            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("There is no command or path like this\n127\n", logger.lastConsoleWrite);
        }
        [Test]
        public void CheckTildaAfterNoOkayCommandWithContinueConnector()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "qwe; echo ~";
 
            bash.RunCommand(commandParser, command);
            
            Assert.AreEqual("There is no command or path like this\n0\n", logger.lastConsoleWrite); 
        }


        [Test]
        public void CheckTildaAfterNoOkayCatCommand()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "cat qwe";
            bash.RunCommand(commandParser, command);
            command = "echo ~";
            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("No such file or directory\n0\n", logger.lastConsoleWrite);
        }
    }

}

using System;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class TrueAndFalseCommandsTests
    {
        [Test]
        public void CheckTrueWithAndConnector() // & (&& in original Bash)
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "true & echo 5";
            bash.RunCommand(commandParser, command);
            Assert.AreEqual("5\n", logger.lastConsoleWrite);

        }

        [Test]
        public void CheckTrueWithOrConnectors() // | (|| in original Bash)
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "true | echo 5";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("", logger.lastConsoleWrite);
        }

        [Test]
        public void CheckFalseWithAndConnector() // & (&& in original Bash)
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "false & echo 5";
            bash.RunCommand(commandParser, command);
            Assert.AreEqual("", logger.lastConsoleWrite);

        }

        [Test]
        public void CheckFalseWithOrConnectors() // | (|| in original Bash)
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "false | echo 5";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5\n", logger.lastConsoleWrite);
        }

    }

}

using System;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class DollatAtCommandsTests
    {
        [Test]
        public void CheckDollarAndAtWithEmptyString()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "$ a";
            bash.RunCommand(commandParser, command);

            command = "$ a += ";

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            bash.RunCommand(commandParser, command);

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            command = "echo @a";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("\n", logger.lastConsoleWrite);
        }

        [Test]
        public void CheckDollarAndAtWithNoString()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "$ a = 5q";
            bash.RunCommand(commandParser, command);

            command = "$ a += 6q";

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            bash.RunCommand(commandParser, command);

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            command = "echo @a";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5q6q\n", logger.lastConsoleWrite);

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            command = "$ a = 7q";
            bash.RunCommand(commandParser, command);

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            command = "echo @a";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5q6q\n7q\n", logger.lastConsoleWrite); // a is now 7q.

        }

        [Test]
        public void CheckDollarAndAtWithNoExistsVariable()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "echo @a";

            bash.RunCommand(commandParser, command);

            Assert.AreEqual("@a\n", logger.lastConsoleWrite);
        }

    }

}

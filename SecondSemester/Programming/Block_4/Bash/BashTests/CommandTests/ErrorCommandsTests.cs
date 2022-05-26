using System.IO;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests
{
    public class ErrorCommandsTests
    {

        [Test]
        public void ErrorCommandTest()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "pwdq qwerty qwert qwer";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("There is no command or path like this\n", logger.lastConsoleWrite);
        }

        [Test]
        public void WhitespaceCommandTest()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = " q";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("There is no command or path like this\n", logger.lastConsoleWrite);
        }

        [Test]
        public void TwoCommandsWithSecondErrorCommandTest()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "echo 5; q";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5\nThere is no command or path like this\n", logger.lastConsoleWrite);
        }

        [Test]
        public void TwoErrorCommandsTest()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "ech 5; q";
            bash.RunCommand(commandParser, command);

            var exceptedOutput = "There is no command or path like this\n";

            Assert.AreEqual(exceptedOutput + exceptedOutput, logger.lastConsoleWrite);
            
        }
    }
}

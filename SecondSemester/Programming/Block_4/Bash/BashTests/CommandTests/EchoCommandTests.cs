using System;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class InputCommandsAndScriptsTests
    {
        [Test]
        public void CheckInputsTests()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "echo 5 6 7 echo q";
            bash.RunCommand(commandParser, command);

            Assert.AreEqual("5 6 7 echo q\n", logger.lastConsoleWrite);
        }
    }

}

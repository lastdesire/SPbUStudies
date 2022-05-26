using System;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class WcTests
    {
        [Test]
        public void WcTest()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var path = "../../../TxtExamples/example.txt";
            var command = "wc " + path;
            bash.RunCommand(commandParser, command);

            var expectedResult = "4 4 24\n";

            Assert.AreEqual(expectedResult, logger.lastConsoleWrite);
        }
    }

}

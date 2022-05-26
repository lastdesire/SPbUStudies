using System.IO;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests
{
    public class PwdTests
    {

        [Test]
        public void CurrentPwdCheckWithNoArguments()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "pwd";
            bash.RunCommand(commandParser, command);

            var currPath = Directory.GetCurrentDirectory();
            var pathInfo = new DirectoryInfo(currPath);

            var expectedOutput = "";
            expectedOutput += currPath + '\n';
            foreach (var file in pathInfo.EnumerateFiles())
            {
                expectedOutput += file.Name + '\n';
            }

            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }

        [Test]
        public void CurrentPwdCheckWithSomeArguments()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "pwd qwerty qwert qwer";
            bash.RunCommand(commandParser, command);

            var currPath = Directory.GetCurrentDirectory();
            var pathInfo = new DirectoryInfo(currPath);

            var expectedOutput = "";
            expectedOutput += currPath + '\n';
            foreach (var file in pathInfo.EnumerateFiles())
            {
                expectedOutput += file.Name + '\n';
            }

            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }

    }
}

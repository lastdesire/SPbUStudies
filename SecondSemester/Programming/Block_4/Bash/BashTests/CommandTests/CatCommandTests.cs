using System.IO;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests
{
    public class CatCommandTests
    {

        [Test]
        public void CatCheckWithSomeArguments()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "cat ../../../TxtExamples/example.txt ../../../TxtExamples/example1.txt";
            bash.RunCommand(commandParser, command);

            var expectedOutput = "12345\n67890\n09876\n54321\n" + "example1\nsome\ntext for\nexample\n";


            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }

        [Test]
        public void CatCheckWithOneArgument()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "cat ../../../TxtExamples/example.txt";
            bash.RunCommand(commandParser, command);

            var expectedOutput = "12345\n67890\n09876\n54321\n";


            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }

        [Test]
        public void CatCheckWithNoArguments()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "cat";
            bash.RunCommand(commandParser, command);

            var expectedOutput = "\n";


            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }

        [Test]
        public void CatCheckWithErrorArguments()
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var command = "cat q q";
            bash.RunCommand(commandParser, command);

            var expectedOutput = "No such file or directory\nNo such file or directory\n";


            Assert.AreEqual(expectedOutput, logger.lastConsoleWrite);
        }
    }
}

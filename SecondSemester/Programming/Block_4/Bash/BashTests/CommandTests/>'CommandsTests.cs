using System;
using System.IO;
using Bash.Bash;
using NUnit.Framework;

namespace BashTests.CommandTests
{
    public class InputCommandTests
    {
        [Test]
        public void WriteAndRewriteCommandsTest() // > and ' (>> in original Bash)
        {
            var logger = new Bash.BashOutput.Logger();
            var bash = new MyBash(logger);
            var commandParser = new CommandParser();
            var path = "../../../TxtExamples/exampleInput.txt";
            var command = "echo qwerty " + "> " + path;
            bash.RunCommand(commandParser, command);

            string text;
            try
            {
                text = File.ReadAllText(path);

            }
            catch (Exception)
            {
                text = ("No such file or directory\n");
            }


            Assert.AreEqual(text, "qwerty ");

            commandParser.Connectors.Clear();
            commandParser.Commands.Clear();

            command = "echo qwert " + "' " + path;

            bash.RunCommand(commandParser, command);

            try
            {
                text = File.ReadAllText(path);

            }
            catch (Exception)
            {
                text = ("No such file or directory\n");
            }


            Assert.AreEqual(text, "qwerty qwert ");
        }
    }

}

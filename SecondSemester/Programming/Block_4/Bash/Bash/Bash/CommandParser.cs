using System;
using System.Collections.Generic;
using System.Text;

namespace Bash.Bash
{
    // For example: echo 1 2 3 echo 4; echo 5
    // Result: 1 2 3 echo 4
    //         5
    // Commands = ["echo 1 2 3 echo 4", "echo 5"]
    // CommandsResult = [true, true]
    // Connectors = [";"]
    public class CommandParser // Класс, позволяющий парсить методы и следить за результатом выполнения последней команды.
    {
        public List<string> Commands; // Содержит список команд.

        public int lastResult;

        // Массив, содержащий последний вывод.
        // Суть такая же, как и у поля lastWrite класса Logger, однако этот массив служит для других целей.
        // Он организовывает корректную работу команд > и '.
        // То есть, например, есть команда "echo 5 > example.txt";
        // Нужно где-то хранить результат "echo 5".
        // В этом и помогает этот массив.
        public string[] lastWrite;

        public List<char> Connectors; // Содержит список коннекторов '&', '|', ';'.

        public CommandParser()
        {
            Commands = new List<string>();
            Connectors = new List<char>();
            lastResult = 0;
            lastWrite = Array.Empty<string>();
        }


        // Метод, парсящий строку, которую ввел пользователь, в относительно удобном для работы виде.
        public void ParseCommand(string commands)
        {
            // StringBuilder более оптимизирован под символьную работу со строками.
            var command = new StringBuilder();

            // Парсим строку посимвольно.
            foreach (var item in commands)
            {
                if (item == '~') // Меняем ~ ($? в bash'е) на последний результат исполнения команды.
                {
                    var strLastResult = lastResult.ToString();
                    var len = strLastResult.Length;
                    for(var i = 0; i < len; i++)
                    {
                        command.Append(strLastResult[i]);
                    }
                }

                else if (item == ';' || item == '&' || item == '|') // Добавляем в массив коннектор и команду, идущую до него.
                {
                    Commands.Add(command.ToString());
                    command.Length = 0;
                    Connectors.Add(item);
                }

                // Добавляем команду, идущую до вспомогателей ввода, затем добавляем коннектор &, чтобы следующая команда,
                // которая начинается с > или ' обязательно выполнилась только при выполнении предыдущей команды.
                else if (item == '>' || item == '\'')
                {
                    Commands.Add(command.ToString());
                    command.Clear();
                    command.Append(item);
                    Connectors.Add('&');
                }

                // Если не встретилось ничего из вышеперечисленного, то текущий символ входит в комманду.
                else
                {
                    command.Append(item);
                }
            }

            // Добавляем последнюю команду.
            Commands.Add(command.ToString());
            command.Clear();
        }
    }
}

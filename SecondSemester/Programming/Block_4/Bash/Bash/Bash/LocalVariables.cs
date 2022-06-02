using System;
using System.Collections;

namespace Bash.Bash
{
    public class LocalVariables // Класс, который позволяет хранить локальные переменные, реализуя Hashtable.
    {
        public Hashtable localVariables = new Hashtable();

        public string CreateNewVariable(string[] args) // Создает новую переменную, название которой равно args[0] (значение "").
        {
            if (Int32.TryParse(args[0][0].ToString(), out int parseResult)) // First char can't be integer.
            {
                return ("You can't add variables with first integer char");
            }
            else if (!localVariables.Contains($"{args[0]}"))
            {
                localVariables.Add($"{args[0]}", "");
                return "";
            }
            return "";
        }

        // Создает новую переменную, название которой равно args[0] (значение args[2]).
        // args[1] = '='.
        // Пример: $ a = 5;
        // $ -- команда; a, = , 5 -- аргументы команды.
        public string AssignValueToVariable(string[] args)
        {
            if (Int32.TryParse(args[0][0].ToString(), out int parseResult)) // First char can't be integer.
            {
                return ("You can't add variables with first integer char");
            }

            if (!localVariables.Contains(args[0]))
            {
                localVariables.Add($"{args[0]}", $"{args[2]}");
            }
            else
            {
                localVariables[args[0]] = args[2];
            }
            return "";
        }

        // Добавляет к существующей переменной строку. Если переменной не существует, то создает ее с указанной строкой.
        // args[1] = "+=".
        // Пример: $ a += 5;
        // $ -- команда; a, += , 5 -- аргументы команды.
        public string AddValueToVariable(string[] args)
        {
            if (Int32.TryParse(args[0][0].ToString(), out int parseResult)) // First char can't be integer.
            {
                return ("You can't add variables with first integer char");
            }

            if (localVariables.Contains(args[0]))
            {
                var oldStr = localVariables[$"{args[0]}"];
                var newStr = oldStr + args[2];
                localVariables[args[0]] = oldStr + args[2];
            }
            else
            {
                localVariables.Add($"{args[0]}", $"{args[2]}");
            }
            return "";
        }
    }
}

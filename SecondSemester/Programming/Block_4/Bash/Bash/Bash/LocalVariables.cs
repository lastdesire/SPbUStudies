using System;
using System.Collections;

namespace Bash.Bash
{
    public class LocalVariables
    {
        public Hashtable localVariables = new Hashtable();

        public string CreateNewVariable(string[] args) // Создает новую переменную, название которой равно args[0].
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

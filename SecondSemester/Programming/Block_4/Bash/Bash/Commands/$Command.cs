using System.Collections.Generic;
using Bash.Bash;

namespace Bash.Commands
{ 

    public class DollarCommand // Инициализация и изменение локальных переменных (например, "$ a += 5").
    {
        public string Name { get; protected set; } = "$";

        public string[] Run(string[] args, LocalVariables localVariables)
        {
            var result = new List<string>();
            if (args.Length == 0) // $
            {
                result.Add("There is no command \"$\"");
            }
            else if (args.Length <= 2) // $ a [OR] $ a something
            {
                result.Add(localVariables.CreateNewVariable(args));
            }
            else if (args.Length >= 3)
            {
                if (args[1] == "=")
                {
                    result.Add(localVariables.AssignValueToVariable(args));
                }
                else if (args[1] == "+=")
                {
                    result.Add(localVariables.AddValueToVariable(args));
                }
                else
                {
                    result.Add(localVariables.CreateNewVariable(args));
                }
            }
            return result.ToArray();
        }

    }
}

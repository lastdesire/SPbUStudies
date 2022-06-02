namespace Bash.Commands
{
    public abstract class Command // Абстрактный класс для упрощенной реализации некоторых команд.
    {
        public abstract string Name { get; protected set; }
        public abstract string[] Run(string[] args);

        public string[] Run()
        {
            var args = new string[0];
            return Run(args);
        }

        public string[] Run(string arg)
        {
            var args = new string[1];
            args[0] = arg;
            return Run(args);
        }
    }
}

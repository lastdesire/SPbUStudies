using System;

namespace DotaCardGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintDescription();
            var player1 = new Player(1, Convert.ToBoolean(0));
            var player2 = new Player(2, Convert.ToBoolean(1));
            var game = new Game();
            Game.StartGame(player1, player2);
        }

        public static void PrintDescription()
        {
            Console.WriteLine("Это Карточная игра по Dota 2. С правилами игры вы можете ознакомиться в файле " +
                              "\"Readme\".");
        }
    }
}
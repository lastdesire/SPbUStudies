using System;

namespace DotaCardGame
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            PrintDescription();
            var player1 = new Player(1, false); // Создаем двух игроков, параметры: номер игрока, AI ли это? 
            var player2 = new Player(2, true);
            var game = new Game(); // Создаем игру, запускаем.
            Game.StartGame(player1, player2); 
        }

        public static void PrintDescription()
        {
            Console.WriteLine("Это Карточная игра по Dota 2. С правилами игры вы можете ознакомиться в файле " +
                              "\"Readme\".");
        }
    }
}

using System;

namespace DotaCardGame
{
    public class Game
    {
        public static void StartGame(Player player1, Player player2)
        {
            player2.HealHp(40); // Для баланса.
            Console.WriteLine("Игра началась.");
            for (var i = 0; i < 8; i++)
            {
                player1.Inventory[i] = Deck.GetCard();
                player2.Inventory[i] = Deck.GetCard();
            }
            player1.SpellPocket = Deck.GetSpell();
            player2.SpellPocket = Deck.GetSpell();
            Console.WriteLine("Игроки получили свои карточки.");
            var turn = 1;

            while (turn != 1000)
            {
                if (turn % 6 == 0)
                {
                    player1.SpellPocket = Deck.GetSpell();
                    player2.SpellPocket = Deck.GetSpell();
                }

                if (turn % 10 == 0)
                {
                    for (var i = 0; i < 8; i++)
                    {
                        player1.Inventory[i] = Deck.GetCard();
                        player2.Inventory[i] = Deck.GetCard();
                    }
                }
                if (turn % 2 == 1)
                {
                    Console.WriteLine("///////////////////////// Round {0}: Ход {1} игрока /////////////////////////", turn, player1.Number);
                    Move(player1, player2);
                    turn += 1;
                }
                else
                {
                    Console.WriteLine("///////////////////////// Round {0}: Ход {1} игрока /////////////////////////", turn, player2.Number);
                    Move(player2, player1);
                    turn += 1;
                }
            }
            Console.WriteLine("Игра длилась слишком долго. Победила дружба.");
        }
        
        private static void Move(Player player, Player enemy)
        {
            PrintInfoAboutPlayers(player, enemy);
            PrintInventory(player);
            PlayPocket(player, enemy);
            for (var i = 0; i < 3; i++)
            {
                CardOnTheField(player, enemy, i);
                FieldBattle(player, enemy, i);
            }
            
        }
        
        private static void PrintInfoAboutPlayers(Player player, Player enemy)
        {
            Console.WriteLine("Ваше хп: {0}, ваша мана: {1}", player.Hp, 0);
            PrintInfoAboutFields(player);
            Console.WriteLine("");
            Console.WriteLine("/Хп врага: {0}, мана врага: {1}/", enemy.Hp, 0);
            PrintInfoAboutFields(enemy);
            Console.WriteLine("");
        }
        
        private static void PrintInventory(Player player)
        {
            Console.WriteLine("Инвентарь игрока:");
            for (int i = 0; i < 8; i++)
            {
                Console.Write("{0}:", i + 1);
                if (player.Inventory[i] == null)
                {
                    Console.WriteLine("Слот инвентаря пуст");
                }
                else
                {
                    player.Inventory[i].InfoAboutCharacter();
                }
            }
            Console.Write("Карман: ");
            if (player.SpellPocket == null)
            {
                Console.WriteLine("Пусто");
            }
            else
            {
                player.SpellPocket.PrintInfoAboutSpell();
            }
            Console.WriteLine("");

        }
        
        private static void PlayPocket(Player player, Player enemy)
        {
            if (player.SpellPocket != null)
            {
                Console.WriteLine(
                    "Хотите ли вы использовать предмет в вашем кармане? Да (введите 1) или нет (введите 0):");
                var answer = EnteringCorrectChooseValue(player);
                if (answer == 1)
                {
                    player.SpellPocket.Usage(player, enemy);
                    player.SpellPocket = null;
                    Console.WriteLine("Вы воспользовались предметом в кармане.");
                }
                else
                {
                    Console.WriteLine("Вы решили не использовать предмет.");
                }
            }
            else
            {
                Console.WriteLine("В вашем кармане пусто, вы не можете использовать никакой спелл.");
            }
        }

        private static void CardOnTheField(Player player, Player enemy, int fieldNumber)
        {
            var counterOfAvailableCards = 0;
            if (player.Fields[fieldNumber] == null)
            { 
                Console.WriteLine("Ваше поле {0} пусто.", fieldNumber + 1);
            }
            else
            {
                Console.Write("На вашем поле {0}: ", fieldNumber + 1);
                player.Fields[fieldNumber].InfoAboutCharacter();
            }

            if (enemy.Fields[fieldNumber] == null)
            { 
                Console.WriteLine("Поле {0} противника пусто.", fieldNumber + 1);
            }
            else
            {
                Console.Write("На поле {0} противника: ", fieldNumber + 1);
                enemy.Fields[fieldNumber].InfoAboutCharacter();
            }
            
            for (var j = 0; j < 8; j++)
            {
                if (player.Inventory[j] != null)
                {
                    counterOfAvailableCards += 1;
                }
            }

            if (counterOfAvailableCards == 0)
            {
                Console.WriteLine("У вас нет доступных карт, которые вы можете разместить на поле.");
            }
            else
            {
                Console.WriteLine("Выберите карту, которую хотите разместить на поле. Введите в консоль номер этой карты. " +
                                  "Если не хотите размещать на поле что-либо, то введите 0.");
                var answer = EnteringCorrectValue(player);

                if (answer == 0)
                {
                    Console.WriteLine("Вы решили не размещать на поле карту.");
                }
                else
                {
                    player.Fields[fieldNumber] = player.Inventory[answer - 1];
                    Console.Write("Вы разместили на поле карту ");
                    player.Fields[fieldNumber].InfoAboutCharacter();
                    player.Inventory[answer - 1] = null;
                }
            }
        }

        private static void FieldBattle(Player player, Player enemy, int fieldNumber)
        {
            if (enemy.Fields[fieldNumber] == null)
            {
                if (player.Fields[fieldNumber] == null)
                {
                    Console.WriteLine("Ваше поле пусто.");

                }
                else
                {
                    Console.WriteLine("На вашем поле находится: ");
                    player.Fields[fieldNumber].InfoAboutCharacter();
                    ChooseAndUseSkillOrDamage(player, enemy, player.Fields[fieldNumber], enemy);
                    DestroyDeadCharacters(player, enemy);
                    PrintInfoAboutPlayers(player, enemy);
                }
            }
            else
            {
                if (player.Fields[fieldNumber] == null)
                {
                    Console.WriteLine("Ваше поле пусто.");
                }
                else
                {
                    ChooseAndUseSkillOrDamage(player, enemy, player.Fields[fieldNumber], enemy.Fields[fieldNumber]);
                    DestroyDeadCharacters(player, enemy);
                    PrintInfoAboutPlayers(player, enemy);
                }
            }
            Console.WriteLine("");
            
        }

        private static void PrintInfoAboutFields(Player player)
        {
            Console.WriteLine("Поля: ");
            for (var i = 0; i < 3; i++)
            {
                Console.Write("{0}: ", i + 1);
                if (player.Fields[i] == null)
                {
                    Console.WriteLine("Поле пусто");
                }
                else
                {
                    player.Fields[i].InfoAboutCharacter();
                }
            }
        }
        
        private static void ChooseAndUseSkillOrDamage(Player player, Player enemy, Character damageDealer, Target damageTaker)
        {
            if (damageDealer.SkillManaCost > damageDealer.Mana)
            {
                Console.WriteLine("Маны на скилл недостаточно. Вариант один: нанести базовый урон.");
                damageTaker.TakeDamage(damageDealer.BaseDamage);
                return;
            }
            Console.WriteLine("Выберите, что хотите использовать: Базовый урон персонажа (введите 0) или его скилл (введите 1):");
            damageDealer.PrintSkillInfo();
            var answer = EnteringCorrectChooseValue(player);
            if (answer == 0)
            {
                Console.WriteLine("Вы решили нанести базовый урон"); //!!!!!
                damageTaker.TakeDamage(damageDealer.BaseDamage);
            }
            else
            {
                Console.WriteLine("Вы воспользовались скиллом персонажа.");
                damageDealer.Skill(player, enemy, damageTaker);
            }
        }
        
        private static int EnteringCorrectValue(Player player) // Ввод корректного значения для карты в инвентаре.
        {
            var stringAnswer = "";
            var answerIsNum = int.TryParse(stringAnswer, out var answer);
            while (!answerIsNum)
            {
                Console.WriteLine("(Важно: вводите числа, а также следите за диапазоном!)");
                if (player.IsAi == Convert.ToBoolean(1))
                {
                    Random rnd = new Random();
                    stringAnswer = (rnd.Next(0, 9)).ToString();
                    answerIsNum = int.TryParse(stringAnswer, out answer);
                }
                else
                {
                    stringAnswer = (Console.ReadLine());
                    answerIsNum = int.TryParse(stringAnswer, out answer);
                }

                if (!answerIsNum) continue;
                if (answer > 8 || answer < 0)
                {
                    Console.WriteLine("Вы ввели недопустимое значение.");
                    answerIsNum = false;
                }
                else if (answer == 0)
                {
                    break;
                }
                else if (player.Inventory[answer - 1] == null)
                {
                    Console.WriteLine("Данный слот вашего инвентаря пуст.");
                    PrintInventory(player);
                    answerIsNum = false;
                }
            }
            return answer;
        }

        private static int EnteringCorrectChooseValue(Player player) // Ввод корректного значения для спелла в кармане,
                                                                     // а также для выбора использования скилла или базового урона.
        {
            var stringAnswer = "";
            var answerIsNum = int.TryParse(stringAnswer, out var answer);
            while (!answerIsNum)
            {
                Console.WriteLine("(Важно: вводите число 0 или 1!)");
                if (player.IsAi == Convert.ToBoolean(1))
                {
                    var rnd = new Random();
                    return rnd.Next(0, 2);
                }
                stringAnswer = (Console.ReadLine());
                answerIsNum = int.TryParse(stringAnswer, out answer);
                if (!answerIsNum) continue;
                if (answer == 1 || answer == 0) continue;
                Console.WriteLine("Вы ввели недопустимое значение.");
                answerIsNum = false;
            }
            return answer;
        }
        
        private static void DestroyDeadCharacters(Player player, Player enemy)
        {
            for (var i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    if (enemy.Fields[i].Hp <= 0)
                    {
                        enemy.Fields[i] = null;
                    }
                }
                if (player.Fields[i] == null) continue;
                if (player.Fields[i].Hp <= 0)
                {
                    player.Fields[i] = null;
                }
            }
            if (enemy.Hp <= 0)
            {
                enemy.TakeDamage(0);
            }
        }
    }
}

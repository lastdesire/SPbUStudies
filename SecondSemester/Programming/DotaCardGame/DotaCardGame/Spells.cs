using System;

namespace DotaCardGame
{
    public abstract class Spell
    {
        public abstract void Usage(Player player, Player enemy);

        public abstract void PrintInfoAboutSpell();
    }

    public class HealingSalve : Spell
    {
        public override void Usage(Player player, Player enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                if (player.Fields[i] != null)
                {
                    player.Fields[i].HealHp(5);
                }
            }
            player.HealHp(5);
        }

        public override void PrintInfoAboutSpell()
        {
            Console.WriteLine("HealingSalve: Предмет исцеляет все цели игрока (в том числе и его самого) на 5 единиц здоровья. Может превысить изначальное хп героя.");
        }
    }
    
    public class Clarity : Spell
    {
        public override void Usage(Player player, Player enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                if (player.Fields[i] != null)
                {
                    player.Fields[i].HealMana(8);
                }
            }
        }

        public override void PrintInfoAboutSpell()
        {
            Console.WriteLine("Clarity: Предмет восстанавливает персонажам игрока 8 единиц маны. Может превысить изначальную ману героя.");
        }
    }
    
    public class BattleFury : Spell
    {
        public override void Usage(Player player, Player enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].TakeDamage(6);
                }
            }
            enemy.TakeDamage(6);
        }

        public override void PrintInfoAboutSpell()
        {
            Console.WriteLine("BattleFury: Предмет наносит всем вражеским таргетам 6 единиц урона.");
        }
    }
    
    public class DiffusalBlade : Spell
    {
        public override void Usage(Player player, Player enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].BurnMana(7);
                }
            }
        }

        public override void PrintInfoAboutSpell()
        {
            Console.WriteLine("DiffusalBlade: Предмет сжигает всем вражеским таргетам 7 единиц маны.");
        }
    }

    public class Mango : Spell
    {
        public override void Usage(Player player, Player enemy)
        {
            for (int i = 0; i < 3; i++)
            {
                if (player.Fields[i] != null)
                {
                    player.Fields[i].HealMana(i * 5);
                }
            }
        }

        public override void PrintInfoAboutSpell()
        {
            Console.WriteLine("Mango: Восстанавливает персонажу на первом поле 5 маны, на втором - 10, на третьем - 15.");
        }
    }
}
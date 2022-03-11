using System;

namespace DotaCardGame
{
    public abstract class Target // Абстрактный класс, от которого наследуются персонажи (карточки) и сами игроки.
    {
        public int Hp { get; protected set; }
        protected string Name { get; set; }
        public abstract void TakeDamage(int damage);

        public void HealHp(int heal)
        {
            Hp += heal;
        }
    }

    public abstract class Character : Target // Абстрактный класс, от которого наследуются конкретные персонажи.
    {
        public abstract int BaseDamage { get; }
        public int Mana { get; private set; }
        public readonly int SkillManaCost;
        public abstract void Skill(Player player, Player enemy, Target target);
        public abstract void PrintSkillInfo();
        public override void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp <= 0)
            {
                Hp = 0;
            }
        }
        
        public void InfoAboutCharacter()
        {
            Console.WriteLine("Персонаж: {0}, Hp: {1}, Mana: {2}, BaseDamage: {3}", Name, Hp, Mana, BaseDamage);
        }

        protected Character(string name, int hp, int mana, int skillManaCost)
        {
            Name = name;
            Hp = hp;
            Mana = mana;
            SkillManaCost = skillManaCost;
        }

        public void BurnMana(int value)
        {
            Mana -= value;
            if (Mana < 0)
            {
                Mana = 0;
            }
        }

        public void HealMana(int value)
        {
            Mana += value;
        }
    }

    public class Player : Target // Класс, с помощью которого создаем объекты -- самих игроков.
    {
        public int Number { get; }
        public readonly Character[] Fields = new Character[3]; // Всего три поля на столе.
        public readonly Character[] Inventory = new Character[8]; // Всего не больше 8 карт в инвентаре.
        public Spell SpellPocket; // Всего один спелл.
        public bool IsAi { get; } // Переменная, которая говорит нам о том, является ли игрок ИИ.

        public Player(int number, bool isAi)
        {
            Number = number;
            Hp = 199;
            Fields[0] = null;
            Fields[1] = null;
            Fields[2] = null;
            for (int i = 0; i < 8; i++)
            {
                Inventory[i] = null;
            }
            SpellPocket = null;
            IsAi = isAi;
        }
        
        public override void TakeDamage(int damage)
        {
            Hp -= damage;
            if (Hp > 0)
            {
                return;
            }
            Console.WriteLine("Ваш ход убивает противника. Вы победили.");
            Console.WriteLine("GAME OVER.");
            Environment.Exit(0);
        }
    }
}

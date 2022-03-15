using System;

namespace DotaCardGame
{
    // Ниже описаны классы, которые реализуют конкретных персонажей игры.
    public class Windranger : Character
    {
        public Windranger() : base("Windranger", 66, 44, 34)
        {
        }

        public override int BaseDamage => 18;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            target.TakeDamage((int) (18 * 1.5));
        }

        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Powershot: заряжает лук сильнее, увеличивая свой дамаг в 1.5 раза. Стоимость: 34 маны.");
        }
    }

    public class Pudge : Character
    {
        public Pudge() : base("Pudge", 75, 35, 29)
        {
        }

        public override int BaseDamage => 16;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].TakeDamage(9);
                }
            }
        }
        
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Rot: Использует свое обаяние, нанося каждому полю врага 9 урона. Стоимость: 29 маны.");
        }
    }

    public class Juggernaut : Character
    {
        public Juggernaut() : base("Juggernaut", 70, 39, 30)
        {
        }

        public override int BaseDamage => 20;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            for (int i = 0; i < 3; i++)
            {
                if (player.Fields[i] != null)
                {
                    player.Fields[i].HealHp(9);
                }
            }
        }
        
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Healing Ward: Ставит тотем, хилящий союзников на поле на 8 хп каждого (может превысить изначальное хп героя таким способом). Стоимость: 30 маны.");
        }
    }

    public class Bloodseeker : Character
    {
        public Bloodseeker() : base("Bloodseeker", 71, 38, 33)
        {
        }

        public override int BaseDamage => 21;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            target.TakeDamage(BaseDamage + 15);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Bloodrage: Наносит на 15 урона больше. Стоимость: 33 маны.");
        }
    }

    public class WitchDoctor : Character
    {
        public WitchDoctor() : base("WitchDoctor", 66, 45, 38)
        {
        }

        public override int BaseDamage => 16;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            target.TakeDamage(10);
            player.HealHp(10);
        }
        
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Voodoo Restoration: Хилит игрока на 10 хп, наносит тому, кого должен атаковать столько же урона. Стоимость: 38 маны.");
        }
    }

    public class Bristleback : Character
    {
        public Bristleback() : base("Bristleback", 78, 36, 25)
        {
        }

        public override int BaseDamage => 19;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            enemy.TakeDamage(8);
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].TakeDamage(8);
                }
            }

        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Quill Spray: Наносит всем вражеским таргетам (как персонажам на поле, так и самому игроку) 8 единиц урона. Стоимость: 25 маны.");
        }
    }

    public class PhantomAssasin : Character
    {
        public PhantomAssasin() : base("PhantomAssasin", 70, 38, 26)
        {
        }

        public override int BaseDamage => 23;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            Random rnd = new Random();
            int value = rnd.Next(1, 3);
            if (value == 1)
            {
                target.TakeDamage(BaseDamage);
            }
            else
            {
                target.TakeDamage(BaseDamage * 2);
            }

        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Coup de Grace: С шансом 50% наносит в два раза больше урона. Стоимость: 24 маны.");
        }
    }
    
    public class Terrorblade : Character
    {
        public Terrorblade() : base("Terrorblade", 71, 37, 37)
        {
        }

        public override int BaseDamage => 21;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            var savedTargetHp = target.Hp;
            var savedCharacterHp = Hp;
            target.TakeDamage(savedTargetHp - 1);
            target.HealHp(savedCharacterHp - 1);
            Hp = savedTargetHp;
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Sunder: Меняет свое хп и хп цели местами, также может обменяться хп с вражеским игроком, если напротив его поля пусто (имба!) . Стоимость: 37 маны.");
        }
    }
    
    public class Lion : Character
    {
        public Lion() : base("Lion", 60, 39, 30)
        {
        }

        public override int BaseDamage => 16;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            for (int i = 0; i < 3; i++)
            {
                if (player.Fields[i] != null)
                {
                    player.Fields[i].HealMana(10);
                }
            }
            target.TakeDamage(BaseDamage / 2);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Mana Drain: Восстанавливает всем персонажам, которые находятся на поле 10 маны, также наносит половину урона своей цели . Стоимость: 30 маны.");
        }
    }
    
    public class ShadowFiend : Character
    {
        public ShadowFiend() : base("ShadowFiend", 70, 45, 28)
        {
        }

        public override int BaseDamage => 24;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].TakeDamage(10);
                }
            }
            enemy.TakeDamage(10);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Requiem of Souls: Милый демон выпускает души, нанося 10 урона всем вражеским таргетам. Стоимость: 28 маны.");
        }
    }
    
    public class Puck : Character
    {
        public Puck() : base("Puck", 65, 40, 30)
        {
        }

        public override int BaseDamage => 19;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            if (enemy.Fields[0] != null)
            { 
                enemy.Fields[0].TakeDamage(35);
                
            }
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Dream Coil: Если на первом поле врага находится персонаж, то Puck наносит ему 35 урона. В противном случае, не происходит ничего. Стоимость: 30 маны.");
        }
    }
    
    public class Necrophos : Character
    {
        public Necrophos() : base("Necrophos", 69, 41, 31)
        {
        }

        public override int BaseDamage => 18;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            if (enemy.Fields[0] != null)
            {
                enemy.Fields[0].TakeDamage(30);
                enemy.Fields[0].BurnMana(5);

            }
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Reaper's Scythe: Если на втором поле врага находится персонаж, то Necrophos нанесет ему 30 урона и сожжет 5 маны. В противном случае, не происходит ничего. Стоимость: 31 маны.");
        }
    }
    
    public class Pugna : Character
    {
        public Pugna() : base("Pugna", 68, 49, 40)
        {
        }

        public override int BaseDamage => 17;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            if (enemy.Fields[0] != null)
            {
                var damage = enemy.Fields[0].Hp;
                enemy.Fields[0].TakeDamage(damage - 1);
            }
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Life Drain: Оставляет врагу на первом поле 1 единицу здоровья, если врага на поле нет, то не делает ничего. Стоимость: 40 маны.");
        }
    }
    
    public class AntiMage : Character
    {
        public AntiMage() : base("AntiMage", 70, 30, 29)
        {
        }

        public override int BaseDamage => 24;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            if (enemy.Fields[0] != null)
            {
                var manaDamage = enemy.Fields[0].Mana;
                enemy.Fields[0].BurnMana(manaDamage - 1);
            }
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Mana Break: Оставляет врагу на последнем поле 1 единицу маны, если врага на поле нет, то не делает ничего. Стоимость: 29 маны.");
        }
    }
    
    public class Dazzle : Character
    {
        public Dazzle() : base("Dazzle", 65, 39, 35)
        {
        }

        public override int BaseDamage => 16;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            player.HealHp(18);
            target.TakeDamage(BaseDamage / 2);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Shadow Wave: Хиллит игрока на 18 хп, после чего наносит половину своего базового урона. Стоимость: 35 маны.");
        }
    }

    public class Slark : Character
    {
        public Slark() : base("Slark", 69, 34, 30)
        {
        }

        public override int BaseDamage => 25;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            for (int i = 0; i < 3; i++)
            {
                if (enemy.Fields[i] != null)
                {
                    enemy.Fields[i].TakeDamage(15);
                }
                TakeDamage(10);
            }
       
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Dark Pact: Жертвует 10 хп, нанося каждому персонажу на вражеском поле по 15 урона (может умереть от этого скилла). Стоимость: 30 маны.");
        }
    }
    
    public class Axe : Character
    {
        public Axe() : base("Axe", 75, 34, 33)
        {
        }

        public override int BaseDamage => 19;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            var savedHp = target.Hp;
            target.TakeDamage(savedHp / 2);
            TakeDamage(Hp / 2);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Culling Blade: Снимает цели половину хп, жертвуя своей половиной хп (может быть применена на игрока). Стоимость: 33 маны.");
        }
    }
    
    public class Sniper : Character
    {
        public Sniper() : base("Sniper", 60, 39, 29)
        {
        }

        public override int BaseDamage => 24;

        public override void Skill(Player player, Player enemy, Target target)
        {
            BurnMana(SkillManaCost);
            enemy.TakeDamage(15);
        }
        public override void PrintSkillInfo()
        {
            Console.WriteLine("Скилл Assassinate: Наносит вражескому игроку 15 урона, даже если на вражеском поле находится кто-либо. Стоимость: 29 маны.");
        }
    }
}

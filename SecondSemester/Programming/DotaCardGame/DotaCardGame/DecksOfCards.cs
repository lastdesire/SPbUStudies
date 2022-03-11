using System;

namespace DotaCardGame
{
    public class Deck // Класс, который содержит в себе методы, позволяющие получить случайного персонажа и случайный спелл. 
    {
        public static Character GetCard()
        {
            var rnd = new Random();
            var value = rnd.Next(1, 19); // Получаем случайное число.
            switch (value) // Возвращаем персонажа с помощью этого случайного числа.
            {
                case 1:
                    return new Windranger();
                case 2:
                    return new Pudge();
                case 3:
                    return new Juggernaut();
                case 4:
                    return new Bloodseeker();
                case 5:
                    return new WitchDoctor();
                case 6:
                    return new Bristleback();
                case 7:
                    return new PhantomAssasin();
                case 8:
                    return new Terrorblade();
                case 9:
                    return new Lion();
                case 10:
                    return new ShadowFiend();
                case 11:
                    return new Puck();
                case 12:
                    return new Necrophos();
                case 13:
                    return new Pugna();
                case 14:
                    return new AntiMage();
                case 15:
                    return new Dazzle();
                case 16:
                    return new Slark();
                case 17:
                    return new Axe();
                case 18:
                    return new Sniper();
                default:
                    return new Windranger();
            }
        }
        
        public static Spell GetSpell()
        {
            var rnd = new Random();
            var value = rnd.Next(1, 6); // Получаем случайное число.
            switch (value) // Возвращаем спелл с помощью этого случайного числа.
            {
                case 1:
                    return new HealingSalve();
                case 2:
                    return new Clarity();
                case 3:
                    return new BattleFury();
                case 4:
                    return new DiffusalBlade();
                case 5:
                    return new Mango();
                default:
                    return new HealingSalve();
            }
        }
    }
}

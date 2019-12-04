using System;
using System.Collections.Generic;
using System.Text;

// game controlls

namespace Gladiator_Game
{
    class Game_engine
    {
        Random rnd = new Random();
        Fighters f = new Fighters();
        stats s = new stats();
        
        public void combat()
        {
            while (f.EnemyHP <= 0 || f.GladiatorHP <= 0);
            {
                Console.WriteLine("How do you want to hit?");
                Console.WriteLine("1. Fist");
                Console.WriteLine();
                var chocise = Convert.ToInt32(Console.ReadLine());

                switch (chocise)
                {
                    case 1:
                        f.EnemyHP -= s.FistDamage;
                        Console.WriteLine("Enemy HP: " + f.EnemyHP);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;

                    default:
                        Console.WriteLine("You must choose a number between 1 - 4!");
                        break;
                }
            }
            }
    }
}

//    public Game_engine()
//    {

//        HeroStrengh = random.Next(10, 20);
//        HeroVitality = random.Next(10, 20);
//        Damage = HeroStrengh / 2;
//        Hp = HeroVitality;
//        //TotalDamageDealt = 0;

//        Fights = new List<Fight>();
//    }

//    public int HeroStrengh { get; set; }
//    public int HeroVitality { get; set; }
//    public int Damage { get; set; }
//    public int Hp { get; set; }
//    public int MaxAttempts { get; set; }
//    public int TotalDamageDealt { get; set; }
//    public List<Fight> Fights { get; set; }

//    private int { Random random = new Random();
//}

//private Fight lastFight = null;

//public void SimulateFight(int strengh, int vitality)
//{
//    int damageDealt = strengh / 2;
//    int hpHero = vitality - damageTaken;
//    TotalDamageDealt += damageDealt;
//    HealthLeft = MaxHp - CurretHp;

//    Fight strike = new Fight();
//    strike.DamageDealt = damageDealt;
//    strike.HpHero = hpHero;
//    strike.DamageTaken = damageTaken;
//    strike.HpEnemy = hpEnemy;

//    lastFight = strike;

//    Fights.Add(strike);
//}




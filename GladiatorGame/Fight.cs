using System;
using System.Collections.Generic;
using System.Text;
using Players;

namespace GladiatorGame
{
    class Fight
    {

        public Fight(Player Gladiator, Player Opponent, Player Enemys,Statistics S)
        {
            var P1 = Gladiator;
            var P2 = Opponent;

            Random rnd = new Random();
            if (rnd.Next(0, 10) < 5)
            {
                P1 = Opponent;
                P2 = Gladiator;
            }

            while (true)
            {
                int choice;
                Gladiator.Damage = 0;
                Opponent.Damage = 0;

                DisplayStartInfo(Gladiator, Opponent, Enemys);

                
                if (P1 == Gladiator)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("Choose your strike method");
                    Console.WriteLine("1. Fist");
                    Console.WriteLine("2. Kick");
                    Console.WriteLine("3. Knee");
                    Console.WriteLine("-------------------------");

                    choice = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    choice = rnd.Next(1, 3);
                }

                switch (choice)
                {
                    case 1:
                        int s1 = P1.Fist();
                        Console.WriteLine($"Fist strike! Damage by {P1.Name}: {s1}");
                        Console.WriteLine();
                        P2.Health -= s1;
                        P1.Damage = s1;
                        break;
                    case 2:
                        int s2 = P1.Kick();
                        Console.WriteLine($"Kick strike! Damage by {P1.Name}: {s2}");
                        Console.WriteLine();
                        P2.Health -= s2;
                        P1.Damage = s2;
                        break;
                    case 3:
                        int s3 = P1.Knee();
                        Console.WriteLine($"Knee strike! Damage by {P1.Name}: {s3}");
                        Console.WriteLine();
                        P2.Health -= s3;
                        P1.Damage = s3;
                        break;
                    default:
                        break;
                }

                P1.Strikes++;
                Gladiator.TotalStrikes += Gladiator.Strikes;
                P1.FightDmg += P1.Damage;
                P2.FightDmg += P2.Damage;
                P1.TotalDmg += P1.Damage;
                P2.TotalDmg += P2.Damage;
                Enemys.TotalStrikes += Opponent.Strikes;
                Enemys.TotalDmg += Opponent.Damage;

                if (P2.Health <= 0)
                {
                    Console.WriteLine($"{P2.Name} knocked!");
                    P2.Health = 0;
                    P1.Wins++;
                    Console.WriteLine($"With {P1.Strikes} strikes!");
                    Console.WriteLine($"{P1.Name} has won {P1.Wins} times");
                    Console.WriteLine($"Total damage by {P1.Name} was {P1.FightDmg}");
                    Console.WriteLine($"{P2.Name} made damage by: {P2.FightDmg}");
                    if (Gladiator.Health <= 0)
                    {
                        S.AddToList(Enemys.Round, Gladiator.Strikes, Gladiator.FightDmg);
                    }
                    else
                    {
                        S.AddToList(Enemys.Round, Gladiator.Strikes, Gladiator.FightDmg, Opponent.Name);
                    }

                    Gladiator.FightDmg = 0;
                    Gladiator.Strikes = 0;
                    Enemys.Round++;

                    if (P1 == Gladiator)
                    {
                        Gladiator.RemoveEnemy();
                    }
                    else if (P2 == Gladiator || Gladiator.Health <= 0)
                    {
                        Gladiator.Health = rnd.Next(10, 20);
                        Gladiator.Strenght = rnd.Next(5, 10);
                    }
                    break;
                }

                if (P1 == Gladiator)
                {
                    P1 = Opponent;
                    P2 = Gladiator;
                }
                else
                {
                    P1 = Gladiator;
                    P2 = Opponent;
                }
            }
        }

        public void DisplayStartInfo(Player Gladiator, Player Opponent, Player Enemys)
        {
            Console.WriteLine();
            Console.WriteLine($"Round {Enemys.Round}");
            Console.WriteLine();
            Console.WriteLine($"Gladiator: {Gladiator.Name}");
            Console.WriteLine($"Gladiator HP {Gladiator.Health}");
            Console.WriteLine($"Gladiator Str {Gladiator.Strenght}");
            Console.WriteLine();
            Console.WriteLine($"Opponent: {Opponent.Name}");
            Console.WriteLine($"Opponent HP {Opponent.Health}");
            Console.WriteLine($"Opponent Str {Opponent.Strenght}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
        }
    }
}

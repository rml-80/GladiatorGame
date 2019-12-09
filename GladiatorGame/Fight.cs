using System;
using System.Collections.Generic;
using System.Text;
using Players;

namespace GladiatorGame
{
    class Fight
    {
         
        public Fight(Player Gladiator, Player Opponent, Player Enemys)
        {
            while (true)
            {
                Gladiator.Damage = 0;
                //Gladiator.Strikes = 0;
                Opponent.Damage = 0;
                //Opponent.Strikes = 0;

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
                Console.WriteLine("-------------------------");
                Console.WriteLine("Choose your strike method");
                Console.WriteLine("1. Fist");
                Console.WriteLine("2. Kick");
                Console.WriteLine("3. Knee");
                Console.WriteLine("-------------------------");

                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        int s1 = Gladiator.Fist();
                        Console.WriteLine($"Fist strike! Damage by {Gladiator.Name}: {s1}");
                        Console.WriteLine();
                        Opponent.Health -= s1;
                        Gladiator.Damage = s1;
                        break;
                    case 2:
                        int s2 = Gladiator.Kick();
                        Console.WriteLine($"Kick strike! Damage by {Gladiator.Name}: {s2}");
                        Console.WriteLine();
                        Opponent.Health -= s2;
                        Gladiator.Damage = s2;
                        break;
                    case 3:
                        int s3 = Gladiator.Knee();
                        Console.WriteLine($"Knee strike! Damage by {Gladiator.Name}: {s3}");
                        Console.WriteLine();
                        Opponent.Health -= s3;
                        Gladiator.Damage = s3;
                        break;
                    default:
                        break;
                }
                Gladiator.Strikes++;
                Gladiator.TotalStrikes += Gladiator.Strikes;
                Gladiator.FightDmg += Gladiator.Damage;
                Gladiator.TotalDmg += Gladiator.Damage;

                if (Opponent.Health <= 0)
                {
                    Console.WriteLine("Opponent knocked!");
                    Opponent.Health = 0;
                    Gladiator.Wins++;
                    Console.WriteLine($"With {Gladiator.Strikes} strikes!");                    // FLYTTAD
                    Console.WriteLine($"{Gladiator.Name} has won {Gladiator.Wins} times");
                    Console.WriteLine($"Total damage by {Gladiator.Name} was {Gladiator.FightDmg}");
                    Console.WriteLine($"Opponent made damage by: {Opponent.TotalDmg}");
                    Gladiator.FightDmg = 0;
                    Gladiator.Strikes = 0;
                    Gladiator.RemoveEnemy();
                    Enemys.Round++;
                    break;
                }

                Random rnd = new Random();
                choice = rnd.Next(1, 3);

                switch (choice)
                {
                    case 1:
                        int o1 = Opponent.Fist();
                        Console.WriteLine($"Fist strike! Damage by {Opponent.Name}: {o1}");
                        Console.WriteLine();
                        Gladiator.Health -= o1;
                        Opponent.Damage = o1;
                        break;
                    case 2:
                        int o2 = Opponent.Kick();
                        Console.WriteLine($"Kick strike! Damage by {Opponent.Name}: {o2}");
                        Console.WriteLine();
                        Gladiator.Health -= o2;
                        Opponent.Damage = o2;
                        break;
                    case 3:
                        int o3 = Opponent.Knee();
                        Console.WriteLine($"Knee strike! Damage by {Opponent.Name}: {o3}");
                        Console.WriteLine();
                        Gladiator.Health -= o3;
                        Opponent.Damage = o3;
                        break;
                    default:
                        break;
                }
                Opponent.Strikes++;
                Opponent.TotalDmg += Opponent.Damage;
                Enemys.TotalStrikes += Opponent.Strikes;
                Enemys.TotalDmg += Opponent.Damage;



                if (Gladiator.Health <= 0)
                {
                    Console.WriteLine("Gladiator knocked!");
                    Gladiator.Health = 0;
                    if (Gladiator.Health == 0)
                    {
                        Gladiator.Health = rnd.Next(10, 20);
                        Gladiator.Strenght = rnd.Next(5, 10);
                    }
                    Opponent.Wins++;
                    Enemys.Wins++;
                    Console.WriteLine($"With {Opponent.Strikes} strikes!");                             // FLYTTAD
                    Console.WriteLine($"{Opponent.Name} has won {Opponent.Wins} times");
                    Console.WriteLine($"Total damage by {Opponent.Name} was {Opponent.TotalDmg}");
                    Console.WriteLine($"Gladiator made damage by: {Gladiator.FightDmg}");
                    Gladiator.FightDmg = 0;
                    Gladiator.Strikes = 0;
                    Enemys.Round++;
                    break;
                }

                //Console.WriteLine();
                //Console.WriteLine($"Total damage by {Gladiator.Name} is {Gladiator.TotalDmg}");
                //Console.WriteLine($"Total damage by {Opponent.Name} is {Opponent.TotalDmg}");
                //Console.WriteLine();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Players;

namespace GladiatorGame
{
    class Fight
    {
        public Fight(Player Gladiator, Player Opponent)
        {
            
            while (true)
            {
                Gladiator.Damage = 0;
                Opponent.Damage = 0;

                Console.WriteLine($"Gladiator HP {Gladiator.Health}");
                Console.WriteLine($"Gladiator Str {Gladiator.Strenght}");
                Console.WriteLine();
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
                Gladiator.TotalDmg += Gladiator.Damage;

                if (Opponent.Health <= 0)
                {
                    Console.WriteLine("Opponent knocked!");
                    Gladiator.Wins++;
                    Console.WriteLine($"{Gladiator.Name} has won {Gladiator.Wins} times");
                    Console.WriteLine($"With {Gladiator.Strikes} strikes!");
                    Console.WriteLine($"Total damage by {Gladiator.Name} was {Gladiator.Damage}");
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
                Opponent.TotalStrikes += Opponent.Strikes;
                Opponent.TotalDmg += Opponent.Damage;

                if (Gladiator.Health <= 0)
                {
                    Console.WriteLine("Gladiator knocked!");
                    Opponent.Wins++;
                    Console.WriteLine($"{Opponent.Name} has won {Opponent.Wins} times");
                    Console.WriteLine($"With {Opponent.Strikes} strikes!");
                    Console.WriteLine($"Total damage by {Opponent.Name} was {Opponent.Damage}");
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

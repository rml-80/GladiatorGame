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
            Stats G = new Stats();
            while (true)
            {
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
                        Console.WriteLine($"Damage by {Gladiator.Name}: {Gladiator.Fist(Gladiator.Strenght)}");
                        Console.WriteLine();
                        Opponent.Health -= Gladiator.Fist(Gladiator.Strenght);
                        break;
                    case 2:
                        Console.WriteLine($"Damage by {Gladiator.Name}: {Gladiator.Kick(Gladiator.Strenght)}");
                        Console.WriteLine();
                        Opponent.Health -= Gladiator.Kick(Gladiator.Strenght);
                        break;
                    case 3:
                        Console.WriteLine($"Damage by {Gladiator.Name}: {Gladiator.Knee(Gladiator.Strenght)}");
                        Console.WriteLine();
                        Opponent.Health -= Gladiator.Knee(Gladiator.Strenght);
                        break;
                    default:
                        break;
                }

                if (Opponent.Health <= 0)
                {
                    Console.WriteLine("Opponent knocked!");
                    G.GladiatorWins++;
                    Console.WriteLine($"{Gladiator.Name} has won {G.GladiatorWins} times");
                    break;
                }

                Random rnd = new Random();
                choice = rnd.Next(1, 3);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Fist strike! Damage by {Opponent.Name}: {Opponent.Fist(Opponent.Strenght)}");
                        Console.WriteLine();
                        Gladiator.Health -= Opponent.Fist(Opponent.Strenght);
                        break;
                    case 2:
                        Console.WriteLine($"Kick strike! Damage by {Opponent.Name}: {Opponent.Kick(Opponent.Strenght)}");
                        Console.WriteLine();
                        Gladiator.Health -= Gladiator.Kick(Opponent.Strenght);
                        break;
                    case 3:
                        Console.WriteLine($"Knee strike! Damage by {Opponent.Name}: {Opponent.Knee(Opponent.Strenght)}");
                        Console.WriteLine();
                        Gladiator.Health -= Opponent.Knee(Opponent.Strenght);
                        break;
                    default:
                        break;
                }

                if (Gladiator.Health <= 0)
                {
                    Console.WriteLine("Gladiator knocked!");
                    G.OpponentWins++;
                    Console.WriteLine($"{Opponent.Name} has won {G.OpponentWins} times");
                    break;
                }
                Console.WriteLine();
                Console.WriteLine($"{Gladiator.Name} HP: {Gladiator.Health}");
                Console.WriteLine($"{Opponent.Name} HP: {Opponent.Health}");
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GladiatorGame
{
    class Fight
    {
        public Fight(Player Gladiator, Player Opponent)
        {
            while (true)
            {
                Console.WriteLine("Choose your strike method");
                Console.WriteLine("1. Fist");
                Console.WriteLine("2. Kick");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Damage by {Gladiator.Name}: {Gladiator.Strenght}");
                        Opponent.Health -= Gladiator.Strenght;
                        break;
                    case 2:
                        Console.WriteLine($"Damage by Gladiator: {Gladiator.Strenght * 2}");
                        Opponent.Health -= (Gladiator.Strenght * 2);
                        break;
                    default:
                        break;
                }
                if (Opponent.Health <= 0)
                {
                    Console.WriteLine($"Enemy knocked!");
                    //playerOne++;
                    break;
                }
                Console.WriteLine($"Damage by {Opponent.Name}: {Opponent.Strenght}");
                Gladiator.Health -= Opponent.Strenght;
                if (Gladiator.Health <= 0)
                {
                    Console.WriteLine($"Gladiator knocked!");
                    //playerTwo++;
                    break;
                }
                Console.WriteLine($"Gladiator HP: {Gladiator.Health}");
                Console.WriteLine($"Enemys HP: {Opponent.Health}");
            }
        }
    }
}

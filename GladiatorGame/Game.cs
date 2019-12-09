using System;
using System.Collections.Generic;
using System.Text;
using Players;

//I denna uppgift ska du skapa ett gladiatorspel, där hjälten slåss mot x antal motståndare, tills han blir besegrad.
//Följande funktioanlitet ska finnas med:
//  - Hjälten ska skapas med ett namn som användaren bestämmer vid programstart(inte hårdkodad). Övriga värden, som styrka(strength) och liv(health) ska slumpas fram
//  - Motståndarna ska också skapas med slumpmässiga värden för styrka och liv, dock på ett sätt som gör de underlägsna vår krigare, i alla fall i början.
//  - Användaren ska välja via menysystem när en ny runda ska börja.Rundan varar så länge en av partena fortfarande har liv kvar.
//  - Om hjälten besegras ska en rapport skapas över alla motståndare han vunnit över och antal poäng (100 poäng för level 1 motståndare, 200 poäng för level 2, osv).
//  - Måtständarna ska öka i svårighetsgrad var tredje runda.Hitta lämplig mekanism att implementera detta.
//  - Hjälten healar sig för 1 liv mellan varje runda med en ny motståndare.
//  - När en motständare besegras ska hjälten ibland kunna hitta följande: pengar (i förm av mer poäng), eler ett magisk föremål som höjer hjältens liv, styrka, eller båda attributen på samma gång
//   T.ex.helm of vitality (ökar livet med 2 enheter), chestpiece of strength(ökar styrkan med 3 enheter).
//  - Man ska kunna se mellan varje runda, vilka prylar som hjälten samlat på sig, via ett menyalternativ(Inventory). Det ska bara finnas 1 av varje, dvs vår hjälte kan inte ha 2 hjälmar på sig samtidigt.
//   Strength prylar byter ut vitality prylar automatiskt, när dessa "hittas", och ifall värdet är högre än föregående värde
//  - Skapa en rapport i en textfil över besegrade motståndare.

namespace GladiatorGame
{
    class Game
    {
        static void Main(String[] args)
        {
            Random rnd = new Random();
            Boolean loop = true;
            Stats s = new Stats();

            Console.WriteLine("Welcome to the arena!!");
            Console.WriteLine("The challanger fights untill death, ppl place ur bets");
            Console.WriteLine("Welcome to the game!");
            Console.Write("Please enter your name: ");

            string n = Console.ReadLine();

            Console.WriteLine($"Welcome {n}, lets see how strong you are today");
            Console.WriteLine("----------------------------------------------------");

            //Create Gladiator TODO move to player
            Player Gladiator = new Player
            {
                Name = n,
                Wins = 0,
                Damage = 0
            };
            //Create Opponent (Enemy)
            Player Opponent = new Player
            {
                Name = string.Empty,
                Wins = 0,
                Damage = 0
            };

            while (loop)
            {
                Gladiator.Health = rnd.Next(10, 20);    // Generate value for Health for each combat
                Gladiator.Strenght = rnd.Next(5, 10);   // Generate value for Strenght for each combat
                Opponent.Name = "Test";
                Opponent.Health = rnd.Next(10, 18);     // Generate value for Health for each combat
                Opponent.Strenght = rnd.Next(5, 10);    // Generate value for Strenght for each combat

                Console.WriteLine("Now where do we wanna send the gladiator??");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("Choise 1: Enter the arena and fight untill death");
                Console.WriteLine("Choise 2: Check stats from last fight");
                Console.WriteLine("Choise 3: Inventory list");
                Console.WriteLine("Choise 4: Exit the game");
                Console.WriteLine("----------------------------------------------------");

                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        _ = new Fight(Gladiator, Opponent);
                        break;

                    case 2:

                        Console.WriteLine();
                        Console.WriteLine($"Gladiator wins: {Gladiator.Wins}");
                        Console.WriteLine($"Damage dealt by gladiator {Gladiator.TotalDmg}");
                        Console.WriteLine($"Strikes by gladiator {Gladiator.TotalStrikes}");
                        Console.WriteLine();
                        Console.WriteLine($"Opponent wins: {Opponent.Wins}");
                        Console.WriteLine($"Damage dealt by opponent {Opponent.TotalDmg}");
                        Console.WriteLine($"Strikes by opponent {Opponent.TotalStrikes}");
                        Console.WriteLine();
                        Console.WriteLine("TEST");
                        Console.WriteLine(s.Stat());

                        break;

                    case 3:

                        break;

                    case 4:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("You must choose a number between 1 - 4!");
                        break;

                }
            }
        }
    }
}
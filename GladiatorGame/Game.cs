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
            Player Enemys = new Player();

            Console.WriteLine("Welcome to the arena!!");
            Console.WriteLine("The challanger fights untill death, ppl place ur bets");
            Console.WriteLine("Welcome to the game!");
            Console.Write("Please enter your name: ");

            string name = Console.ReadLine();

            Console.WriteLine($"Welcome {name}, lets see how strong you are today");
            Console.WriteLine("----------------------------------------------------");

            //Create Gladiator 
            Player Gladiator = new Player(name, rnd.Next(10, 20), rnd.Next(5, 10), 0, 0);

            Gladiator.EnemyNamelist();
            Enemys.Round = 1;       //start counting rounds on 1

            while (loop)
            {
                int E = Gladiator.EnemyNames.Count;
                Console.WriteLine($"Enemys left: {E}");
                if (Gladiator.EnemyNames.Count <= 0)    //if enemylist is empty end game
                {
                    Console.WriteLine($"All Opponents has been beaten. You are the champion!!!!");
                    break;      //break out of the game
                }
                Player Opponent = new Player(Gladiator.EnemyNames[0], rnd.Next(10, 18), rnd.Next(5, 10),0,0);     //Generate new opponent for each fight

                Console.WriteLine();
                Console.WriteLine("Now where do we wanna send the gladiator??");
                Console.WriteLine("----------------------------------------------------");

                Console.WriteLine("Choise 1: Enter the arena and fight untill death");
                Console.WriteLine("Choise 2: Check stats from last fight");
                Console.WriteLine("Choise 3: Enemy list");
                Console.WriteLine("Choise 4: Coming soon!");
                Console.WriteLine("Choise 9: Exit the game");
                Console.WriteLine("----------------------------------------------------");

                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        _ = new Fight(Gladiator, Opponent, Enemys);
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.WriteLine($"Rounds played: {Enemys.Round - 1} ");       // for displaying correct amount of rounds
                        Console.WriteLine();
                        Console.WriteLine($"Gladiator wins: {Gladiator.Wins}");
                        Console.WriteLine($"Damage dealt by gladiator {Gladiator.TotalDmg}");
                        Console.WriteLine();
                        Console.WriteLine($"Opponent wins: {Enemys.Wins}");
                        Console.WriteLine($"Damage dealt by opponent {Enemys.TotalDmg}");

                        break;

                    case 3:
                        Console.WriteLine();
                        foreach (var item in Gladiator.EnemyNames)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine();
                        break;

                    case 4:
                        Console.WriteLine("Coming soon!!!");
                        break;
                    case 9:
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
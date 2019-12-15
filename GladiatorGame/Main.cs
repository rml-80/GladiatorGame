using System;
using System.Collections.Generic;
using System.Text;
using GladiatorGame;

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
            player Enemys = new player();
            Statistics S = new Statistics();
            Equipment items = new Equipment();
            Slaughter Slaughter = new Slaughter();
            report R = new report();
            int MinValueHealth = 10;
            int MaxValueHealth = 20;
            int MinValueStrength = 5;
            int MaxValueStrength = 10;
            items.UsedArmor = false;
            items.UsedWeapon = false;
            int j = 0;

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("--------------- Welcome to the arena!! ---------------");
            Console.WriteLine("The challangers fights untill death, ppl place ur bets");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("---------------- Welcome to the game! ---------------- ");
            Console.Write("Please enter your name: ");

            string name = Console.ReadLine();

            Console.WriteLine($"Welcome {name}, lets see how strong you are today");
            Console.WriteLine("------------------------------------------------------");

            //Create Gladiator 
            player Gladiator = new player(name, rnd.Next(MinValueHealth, MaxValueHealth), rnd.Next(MinValueStrength, MaxValueStrength), 0, 0, 0);

            Gladiator.EnemyNamelist(); // create list with enemys
            Enemys.Round = 1;       //start counting rounds on 1. THIS should be redone.
            Gladiator.Advantage = 2;    // set advantage for Gladiator
            while (loop)
            {
                Console.WriteLine();

                if (Gladiator.EnemyNames.Count <= 0)    //if enemylist is empty end game
                {                                   // Show stats!!!!
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"All Opponents has been beaten. You are the champion!!!!");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("----------- Game created by Daniel & Risto -----------");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to quit");
                    Console.ReadKey();
                    R.CreateReport(Slaughter.Slaughtered,Gladiator.Name, S.Points);
                    break;      //break out of the game
                }

                if (Enemys.Round == 4)
                {
                    Gladiator.Advantage--;  //if
                }
                else if (Enemys.Round == 7)
                {
                    Gladiator.Advantage--;
                }
                int MaxHealthEnemy = Gladiator.Health - Gladiator.Advantage;
                int MaxStrengthEnemy = Gladiator.Strenght - Gladiator.Advantage;

                if (Gladiator.Health - Gladiator.Advantage < MinValueHealth)
                {
                    MaxHealthEnemy = MinValueHealth + 1;
                }
                if (Gladiator.Strenght - Gladiator.Advantage < MinValueStrength)
                {
                    MaxStrengthEnemy = MinValueStrength + 1;
                }

                player Opponent = new player(Gladiator.EnemyNames[0].Name, rnd.Next(MinValueHealth, MaxHealthEnemy), rnd.Next(MinValueStrength, MaxStrengthEnemy), 0, 0, 0);     //Generate new opponent for each fight

                Console.WriteLine();
                if (S.Points == 0)
                {
                    Console.WriteLine("You have not earned any points yet! Start playing.");
                }
                else
                {
                    Console.WriteLine($"Have earned {S.Points} points");

                }
                Console.WriteLine($"Your health is: {Gladiator.Health}\tYour Strenght is: {Gladiator.Strenght}");
                Console.WriteLine();
                Console.WriteLine("Now where do we wanna send the gladiator??");
                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine("Choise 1: Enter the arena and fight untill death");
                Console.WriteLine("Choise 2: Check stats from all fight");
                Console.WriteLine("Choise 3: Enemy list");
                Console.WriteLine("Choise 4: Statistics");
                Console.WriteLine("Choise 5: Armors and Weapons");
                Console.WriteLine("Choise 8: Delete Highscores");
                Console.WriteLine("Choise 9: Exit the game");
                Console.WriteLine("------------------------------------------------------");

                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        _ = new GameEngine(Gladiator, Opponent, Enemys, S, items, Slaughter);
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
                        Console.WriteLine($"Enemys left: {Gladiator.EnemyNames.Count}");
                        Console.WriteLine();
                        
                        for (int i = 0; i < Gladiator.EnemyNames.Count; i++)
                        {
                            if (i == 0)
                            {
                                // needed when one enemy left to print Final Boss
                                if (Gladiator.EnemyNames[i].Level == 4)
                                {
                                    Console.WriteLine("Final Boss:");
                                }
                                else
                                {
                                    Console.WriteLine("Level " + Gladiator.EnemyNames[i].Level + ":");
                                }
                                Console.WriteLine(Gladiator.EnemyNames[i].Name);
                                
                            }
                            else
                            {
                                if (Gladiator.EnemyNames[i].Level == Gladiator.EnemyNames[i - 1].Level)
                                {
                                    Console.WriteLine(Gladiator.EnemyNames[i].Name);
                                }
                                else
                                {
                                    // Print Final Boss for the 10th enemy
                                    if (Gladiator.EnemyNames[i].Level == 4)
                                    {
                                        Console.WriteLine("Final Boss:");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Level " + Gladiator.EnemyNames[i].Level + ":");
                                    }
                                    Console.WriteLine(Gladiator.EnemyNames[i].Name);
                                }
                                
                            }
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Enemys slaughtered: {Slaughter.Slaughtered.Count}");
                        foreach (var item in Slaughter.Slaughtered)
                        {
                            Console.WriteLine(item);
                        }
                        break;


                    case 4:
                        S.DisplayStat();
                        break;
                    case 5:
                        items.Display_A_W(Gladiator);
                        break;
                    case 8:
                        R.DeleteSaves();
                        Console.WriteLine("Are uou sure? y/n?");
                        var a = Console.ReadLine();
                        if (a == "y")
                        {
                            Console.WriteLine("Highscores deleted!");
                        }      
                        break;
                    case 9:
                        loop = false;
                        R.CreateReport(Slaughter.Slaughtered,Gladiator.Name,S.Points);
                        break;

                    default:
                        Console.WriteLine("You must choose a number between 1 - 5 or 9!");
                        break;

                }
            }
        }
    }
}
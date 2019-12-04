using System;
using System.Collections.Generic;
using System.Text;

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
            var Gladiator = "";
            int GladiatorHP = rnd.Next(10, 20); ;
            int GladiatorStr = rnd.Next(5, 10);
            var Enemy = "Test";
            int EnemyHP = rnd.Next(5, GladiatorHP - 1);
            int EnemyStr = rnd.Next(5, 10);
            //var Strike = 1;

            Console.WriteLine("Welcome to the game!");
            Console.Write("Please enter your name: ");
            Gladiator = Console.ReadLine();
            //GladiatorHP = rnd.Next(10, 20);
            //GladiatorStr = rnd.Next(5, 10);

            //Enemy = "test";
            //EnemyHP = rnd.Next(5, GladiatorHP - 1);
            //EnemyStr = rnd.Next(5, 10);

            Console.WriteLine("Let the battle begin!");
            Console.WriteLine($"Gladiator HP: {GladiatorHP}");
            Console.WriteLine($"Enemy HP: {EnemyHP}");

            while (EnemyHP >= 0 && GladiatorHP >= 0)
            {
                Console.WriteLine("Choose your strike method");
                Console.WriteLine("1. Fist");
                Console.WriteLine("2. Kick");
                var choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        EnemyHP -= GladiatorStr;
                        break;
                    case 2:
                        EnemyHP -= (GladiatorStr * 2);
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"Enemys HP: {EnemyHP}");

                GladiatorHP -= EnemyStr;
                Console.WriteLine($"Gladiator HP: {GladiatorHP}");

            }
        }
    }
}

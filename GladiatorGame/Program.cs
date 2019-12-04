using System;

namespace Gladiator_Game
{
    class Program
    {
        static void MainTest(string[] args)
        {
            Boolean loop = true;
            Console.WriteLine("Welcome to the arena!!");
            Console.WriteLine("The challanger fights untill death, ppl place ur bets");
            Console.WriteLine("What is the name of your fighter: ");
            String gladiatorName = Console.ReadLine();

            Console.WriteLine("Welcome ", gladiatorName, " lets see how strong you are today");

            Fighters fight = new Fighters();

            while (loop)
            {
                Console.WriteLine("Now where do we wanna send the gladiator??");
                Console.WriteLine("Choise 1: Enter the arena and fight untill death");
                Console.WriteLine("Choise 2: See stats of the last fighter");
                Console.WriteLine("Choise 3: Inventory list");
                Console.WriteLine("Choise 4: Exit the game");

                int choise = Convert.ToInt32(Console.ReadLine());
                Game_engine ge = new Game_engine();

                switch (choise)
                {
                    case 1:
                        Console.WriteLine("Gladiator HP: " + fight.GladiatorHP);
                        Console.WriteLine("Gladiatorn Strenght: " + fight.GladiatorStr);
                        Console.WriteLine("Enemy HP: " + fight.EnemyHP);
                        Console.WriteLine("Enemy Strenght: " + fight.EnemyStr);
                        ge.combat();

                        break;
                    case 2:

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


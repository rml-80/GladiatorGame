using System;
using System.Collections.Generic;
using System.Text;
using GladiatorGame;

namespace GladiatorGame
{
    class GameEngine
    {
        public GameEngine(player Gladiator, player Opponent, player Enemys, Statistics S, Equipment items, Slaughter Slaughtered)
        {
            var P1 = Gladiator;
            var P2 = Opponent;

            if (items.UsingArmor && !items.UsedArmor)
            {
                Gladiator.Health += items.Armor;        //idea to add ArmorPoints
                items.UsedArmor = true;
            }
            if (items.UsingWeapon && !items.UsedWeapon)
            {
                Gladiator.Strenght += items.Weapon;     //idea to add WeaponPoints
                items.UsedWeapon = true;
            }

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

                DisplayStartInfo(Gladiator, Opponent, Enemys);          // Not a good place to have it

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
                    Console.WriteLine($"{P2.Name} slaughtered!");
                    P2.Health = 0;
                    P1.Wins++;
                    Console.WriteLine($"With {P1.Strikes} strikes!");
                    Console.WriteLine($"{P1.Name} has won {P1.Wins} times");
                    Console.WriteLine($"Total damage by {P1.Name} was {P1.FightDmg}");
                    Console.WriteLine($"{P2.Name} made damage by: {P2.FightDmg}");
                    if (Gladiator.Health <= 0)
                    {
                        S.msg = S.LosingMsg;
                        S.AddToList(Enemys.Round, Gladiator.Strikes, Gladiator.FightDmg, S.msg, Opponent.Name);
                        items.HaveArmor = false;            // losing armor if beaten
                        items.HaveWeapon = false;            // losing Weapon if beaten
                        items.UsingArmor = false;            // losing armor if beaten
                        items.UsingWeapon = false;            // losing Weapon if beaten
                        items.UsedArmor = false;
                        items.UsedWeapon = false;
                        S.Points -= 100;
                    }
                    else
                    {
                        if (Enemys.Round < 4)
                        {
                            S.Points += 100;
                        }
                        else if (Enemys.Round >= 8)
                        {
                            S.Points += 400;
                        }
                        else
                        {
                            S.Points += 200;
                        }
                        S.msg = S.VictoryMsg;
                        S.AddToList(Enemys.Round, Gladiator.Strikes, Gladiator.FightDmg, S.msg, Opponent.Name);
                        Gladiator.Health++;             // add 1 health for victory


                        Console.WriteLine();
                        Console.WriteLine("Chose if u wanna try ur luck on a weapon or armor");
                        Console.WriteLine("1: For armor hunting");
                        Console.WriteLine("2: For weapon hunting");
                        Console.WriteLine("3: Hardcore, no weapon or amror hunt");
                        int itemChoise = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        switch (itemChoise)
                        {
                            case 1:
                                items.ArmorEquipemnt();
                                break;

                            case 2:
                                items.WeaponEquipment();
                                break;

                            default:
                                Console.WriteLine("brave warrior");
                                break;
                        }
                        Console.WriteLine();
                    }
                    Enemys.Wins += Opponent.Wins;
                    Gladiator.FightDmg = 0;
                    Gladiator.Strikes = 0;
                    Enemys.Round++;

                    if (P1 == Gladiator)
                    {
                        Gladiator.RemoveEnemy();
                        Slaughtered.AddToList(Opponent.Name);
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

        public void DisplayStartInfo(player Gladiator, player Opponent, player Enemys)
        {
            Console.WriteLine();
            Console.WriteLine($"Round {Enemys.Round}");
            Console.WriteLine();
            Console.WriteLine($"Gladiator: {Gladiator.Name}\t\tOpponent: {Opponent.Name}");
            Console.WriteLine($"Gladiator HP:  {Gladiator.Health}\tOpponent: {Opponent.Health}");
            Console.WriteLine($"Gladiator Str: {Gladiator.Strenght}\tOpponent: {Opponent.Strenght}");
            //Console.WriteLine();
            //Console.WriteLine($"Opponent: {Opponent.Name}");              //Flyttade
            //Console.WriteLine($"Opponent HP {Opponent.Health}");          //Flyttade
            //Console.WriteLine($"Opponent Str {Opponent.Strenght}");       //Flyttade
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}

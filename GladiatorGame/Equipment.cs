using System;
using System.Collections.Generic;
using System.Text;

namespace GladiatorGame
{
    class Equipment
    {
        public int Armor { get; set; }
        public int Weapon { get; set; }
        private Random rnd = new Random();

        public bool UsingArmor { get; set; }
        public bool UsingWeapon { get; set; }
        public bool HaveArmor { get; set; }
        public bool HaveWeapon { get; set; }
        public bool UsedArmor { get; set; }
        public bool UsedWeapon { get; set; }


        public void ArmorEquipemnt(player Gladiator)
        {

            int rngArmor = rnd.Next(0, 4);

            if (HaveArmor)
            {
                Console.WriteLine("You already have Armor");
            }
            else
            {
                if (rngArmor < 2)
                {
                    Console.WriteLine("sorry no armor found this time");
                }
                if (rngArmor <= 4 && rngArmor >= 2)
                {
                    if (Armor >= 2)
                    {
                        Console.WriteLine("you already have a better armor than the one you found, better luck next time");
                        HaveArmor = true;
                    }
                    else
                    {
                        Armor = 2;
                        Console.WriteLine("grats u found a +{0} armor", Armor);
                        HaveArmor = true;
                        Console.Write("Would you like to put it on? y/n? ");
                        var a = Console.ReadLine();
                        if (a == "y")
                        {
                            UsingArmor = true;
                            Gladiator.Health += Armor;
                        }
                        else
                        {
                            UsingArmor = false;
                        }
                    }
                }
                if (rngArmor == 5)
                {
                    Console.WriteLine("Grats u found the jackpot");
                    Armor = 4;
                    Console.WriteLine("You found a {0}", Armor);
                    HaveArmor = true;
                    Console.Write("Would you like to put it on? y/n? ");

                    var a = Console.ReadLine();
                    if (a == "y")
                    {
                        UsingArmor = true;
                        Gladiator.Health += Armor;
                    }
                    else
                    {
                        UsingArmor = false;
                    }
                }
                if (!HaveArmor || !UsingArmor)
                {
                    Armor = 0;
                }
            }
            Console.WriteLine();
        }

        public void WeaponEquipment(player Gladiator)
        {
            int rngWeapon = rnd.Next(0, 4);

            if (HaveWeapon)
            {
                Console.WriteLine("You already have a Weapon");
            }
            else
            {
                if (rngWeapon < 2)
                {
                    Console.WriteLine("sorry no weapon found this time");
                }
                if (rngWeapon <= 4 && rngWeapon >= 2)
                {
                    if (Weapon == 2)
                    {
                        Console.WriteLine("you already have a better weapon than the one you fund, better luck next time");
                        HaveWeapon = true;
                    }
                    else
                    {
                        Weapon = 2;
                        Console.WriteLine("grats u found a +{0} weapon", Weapon);
                        HaveWeapon = true;
                        Console.Write("Would you like to use it? y/n? ");
                        var a = Console.ReadLine();
                        if (a == "y")
                        {
                            UsingWeapon = true;
                            Gladiator.Strenght += Weapon;
                        }
                        else
                        {
                            UsingWeapon = false;
                        }
                    }
                }
                if (rngWeapon == 5)
                {
                    Console.WriteLine("Grats u found the jackpot");
                    Weapon = 4;
                    Console.WriteLine("You found a {0}", Weapon);
                    HaveWeapon = true;
                    Console.Write("Would you like to use it? y/n? ");
                    var a = Console.ReadLine();
                    if (a == "y")
                    {
                        UsingWeapon = true;
                        Gladiator.Strenght += Weapon;
                    }
                    else
                    {
                        UsingWeapon = false;
                    }
                }
                if (!HaveWeapon || !UsingWeapon)
                {
                    Armor = 0;
                }
            }
            Console.WriteLine();
        }

        public void Display_A_W(player Gladiator)
        {
            Console.WriteLine();
            Console.WriteLine($"Your Gladiator {Gladiator.Name}\nhas a health of {Gladiator.Health}\nand strenght of {Gladiator.Strenght}");
            Console.WriteLine();
            if (HaveArmor)
            {
                Console.WriteLine("You have Armor");
                if (UsingArmor)
                {
                    Console.WriteLine("Your Armor Points are {0}", Armor);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You are not using your Armor");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You have no Armor");
                Console.WriteLine();
            }

            if (HaveWeapon)
            {
                Console.WriteLine("You have a Weapon");
                if (UsingWeapon)
                {
                    Console.WriteLine("Your Weapon Points are {0}", Weapon);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You are not using your Weapon");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("You have no Weapon");
                Console.WriteLine();
            }
            if (HaveArmor || HaveWeapon)
            {

                Console.WriteLine();
                Console.WriteLine("Change Armor or Weapons");
                Console.WriteLine();
                Console.WriteLine("1: Change Armor");
                Console.WriteLine("2: Change Weapon");
                Console.WriteLine("3: Return to main meny");
                var a = int.Parse(Console.ReadLine());

                if (a == 1)
                {
                    //armor
                    if (!HaveArmor)
                    {
                        Console.WriteLine("You have no armor");
                    }
                    else
                    {
                        if (UsingArmor)
                        {
                            Console.Write("Would you like to take it off? y/n? ");
                            var b = Console.ReadLine();
                            if (b == "y")
                            {
                                UsingArmor = false;
                                Gladiator.Health -= Armor;
                            }
                            else
                            {
                                UsingArmor = true;
                            }
                        }
                        else
                        {
                            Console.Write("Would you like to put one on? y/n? ");
                            var b = Console.ReadLine();
                            if (b == "n")
                            {
                                UsingArmor = false;
                            }
                            else
                            {
                                UsingArmor = true;
                                Gladiator.Health += Armor;

                            }
                        }
                    }
                }
                else if (a == 2)
                {
                    //weapons
                    if (!HaveWeapon)
                    {
                        Console.WriteLine("You have no weapon");
                    }
                    else
                    {
                        if (UsingWeapon)
                        {
                            Console.Write("Would you like to leave it? y/n? ");
                            var b = Console.ReadLine();
                            if (b == "y")
                            {
                                UsingWeapon = false;
                                Gladiator.Strenght -= Weapon;
                            }
                            else
                            {
                                UsingWeapon = true;
                            }
                        }
                        else
                        {
                            Console.Write("Would you like to pick up a weapon? y/n? ");
                            var b = Console.ReadLine();
                            if (b == "n")
                            {
                                UsingWeapon = false;
                            }
                            else
                            {
                                UsingWeapon = true;
                                Gladiator.Strenght += Weapon;

                            }
                        }
                    }
                }
            }
        }

    }
}
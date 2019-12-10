﻿using System;
using System.Collections.Generic;
using System.Text;
using Players;

namespace GladiatorGame
{
    class Statistics
    {
        public Statistics()
        {
            Stat = new List<Statistics>();
        }
        public int Round { get; set; }
        public int Strikes { get; set; }
        public int Damage { get; set; }
        public String Beaten { get; set; }
        public List<Statistics> Stat { get; set; }

        public void AddToList(int Round, int Strike, int Damage)
        {
            Stat.Add(new Statistics { Round = Round, Strikes = Strike, Damage = Damage });
        }
        public void AddToList(int Round, int Strike, int Damage, string Beaten)
        {
            Stat.Add(new Statistics { Round = Round, Strikes = Strike, Damage = Damage, Beaten = Beaten });
        }

        public void DisplayStat()
        {
            Console.WriteLine($"Round  Strikes  Damage   Opponent");

            foreach (var item in Stat)
            {
                Console.Write($"  {item.Round} \t  {item.Strikes} \t  {item.Damage} \t {item.Beaten} \n");

            }
        }
    }
}
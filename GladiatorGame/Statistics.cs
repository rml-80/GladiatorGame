using System;
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
        public List<Statistics> Stat { get; set; }

        //List<Statistics> Stat = new List<Statistics>();

        public void AddToList(int Round, int Strike, int Damage)
        {
            Stat.Add(new Statistics { Round = Round, Strikes = Strike, Damage = Damage });
        }

        public void DisplayStat()
        {
            Console.WriteLine($"Round   Strikes  Damage");

            foreach (var item in Stat)
            {
                Console.Write($"{item.Round} \t{item.Strikes} \t {item.Damage} \n");

            }
        }
    }
}

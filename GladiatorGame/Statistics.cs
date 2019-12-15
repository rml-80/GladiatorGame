using System;
using System.Collections.Generic;
using System.Text;
using GladiatorGame;

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
        public int Points { get; set; }
        public List<Statistics> Stat { get; set; }
        public string VictoryMsg = "You just slaughtered ";
        public string LosingMsg = "You have been beaten by ";
        public string msg = String.Empty;

        public void AddToList(int Round, int Strike, int Damage, string msg, string Beaten)
        {
            Stat.Add(new Statistics { Round = Round, Strikes = Strike, Damage = Damage, msg = msg, Beaten = Beaten });
        }
        public void DisplayStat()
        {
            Console.WriteLine();
            Console.WriteLine($"You have earned {Points}");
            Console.WriteLine($"Round  Strikes  Damage   Opponent");

            foreach (var item in Stat)
            {
                Console.Write($"  {item.Round} \t  {item.Strikes} \t  {item.Damage} \t {item.msg}{item.Beaten} \n");
            }
        }
    }

    class Slaughter
    {
        public Slaughter()
        {
            Slaughtered = new List<String>();
        }
        public List<String> Slaughtered { get; set; }

        public void AddToList(string name)
        {
            Slaughtered.Add(name);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Players
{
    class Player
    {
        //public Player() { }

        //public Player(int HP, int Str)
        //{
        //    //name = Name;
        //    HP = Health;
        //    Str = Strenght;
        //}

        public string Name { get; set; }
        public int Health { get; set; }
        public int Strenght { get; set; }
        public int Wins { get; set; }
        public int Strikes { get; set; } // by fight
        public int TotalStrikes { get; set; }
        public int Damage { get; set; } //by fight
        public int TotalDmg { get; set; }

        // methods to calculate damage
        public int Fist()
        {
            int dmg = Strenght / 2;
            return dmg;
        }

        public int Kick()
        {
            int dmg = Strenght;
            return dmg;
        }

        public int Knee()
        {
            int dmg = Strenght / 3;
            return dmg;
        }

        public List<String> EnemyNames = new List<String>();
        
        public void EnemyNamelist()
        {
            EnemyNames.Add("Cassius Gabinius");
            EnemyNames.Add("Marcellus Burrienus");
            EnemyNames.Add("Agaza Kingspell");
            EnemyNames.Add("Jaenwilliams Pomar");
            EnemyNames.Add("Antibar Satanbennett");
            EnemyNames.Add("Roberfang O'neilllok");
            EnemyNames.Add("Drusprice Rosenker");
            EnemyNames.Add("Peaknee Glenalvare");
            EnemyNames.Add("Ortiphine Jonefur");
            EnemyNames.Add("Willpatterson Graylok");
        }

        public void RemoveEnemy()
        {
            EnemyNames.RemoveAt(0);
        }
    }

}



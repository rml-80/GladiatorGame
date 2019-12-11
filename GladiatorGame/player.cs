using System;
using System.Collections.Generic;
using System.Text;

namespace GladiatorGame
{
    class player
    {
        public player() { }

        public player(string Name, int Health, int Strenght)
        {
            this.Name = Name;
            this.Health = Health;
            this.Strenght = Strenght;
            Advantage = 3;
        }
        public player(string Name, int Health, int Strenght, int Strikes, int Damage, int Points)
        {
            this.Name = Name;
            this.Health = Health;
            this.Strenght = Strenght;
            this.Strikes = Strikes;
            this.Damage = Damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Strenght { get; set; }
        public int Wins { get; set; }
        public int Strikes { get; set; } // by fight
        public int TotalStrikes { get; set; }
        public int Damage { get; set; } //by fight
        public int TotalDmg { get; set; }
        public int FightDmg { get; set; }
        public int Round { get; set; }
        public int Advantage { get; set; }

        // methods to calculate damage // TODO random for damage calculation???
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



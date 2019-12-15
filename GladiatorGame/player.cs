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
        public int Level { get; private set; }

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

        public List<player> EnemyNames = new List<player>();

        public void EnemyNamelist()
        {
            EnemyNames.Add(new player { Name = "Cassius Gabinius", Level = 1 });
            EnemyNames.Add(new player { Name = "Marcellus Burrienus", Level = 1 });
            EnemyNames.Add(new player { Name = "Agaza Kingspell", Level = 1 });
            EnemyNames.Add(new player { Name = "Jaenwilliams Pomar", Level = 2 });
            EnemyNames.Add(new player { Name = "Antibar Satanbennett", Level = 2 });
            EnemyNames.Add(new player { Name = "Roberfang O'neilllok", Level = 2 });
            EnemyNames.Add(new player { Name = "Drusprice Rosenker", Level = 3 });
            EnemyNames.Add(new player { Name = "Peaknee Glenalvare", Level = 3 });
            EnemyNames.Add(new player { Name = "Ortiphine Jonefur", Level = 3 });
            EnemyNames.Add(new player { Name = "Willpatterson Graylok", Level = 4 });
            //EnemyNames.Add("Cassius Gabinius");y
            //EnemyNames.Add("Marcellus Burrienus");
            //EnemyNames.Add("Agaza Kingspell");
            //EnemyNames.Add("Jaenwilliams Pomar");
            //EnemyNames.Add("Antibar Satanbennett");
            //EnemyNames.Add("Roberfang O'neilllok");
            //EnemyNames.Add("Drusprice Rosenker");
            //EnemyNames.Add("Peaknee Glenalvare");
            //EnemyNames.Add("Ortiphine Jonefur");
            //EnemyNames.Add("Willpatterson Graylok");
        }

        public void RemoveEnemy()
        {
            EnemyNames.RemoveAt(0);
        }
    }

}
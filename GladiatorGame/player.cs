using System;
using System.Collections.Generic;
using System.Text;

namespace Players
{
    class Player
    {
        public Player(string N, int H, int S)
        {
            Name = N;
            Health = H;
            Strenght = S;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public int Strenght { get; set; }
        
        public int Fist(int dmg)
        {
            dmg = dmg / 2;
            return dmg;
        }

        public int Kick(int dmg)
        {
            return dmg;
        }

        public int Knee(int dmg)
        {
            dmg = dmg / 3;
            return dmg;
        }      
    }
}


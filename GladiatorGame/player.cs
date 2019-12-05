using System;
using System.Collections.Generic;
using System.Text;

namespace GladiatorGame
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

    }
}


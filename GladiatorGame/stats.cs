using System;
using System.Collections.Generic;
using System.Text;
using Players;

namespace GladiatorGame
{
    class Stats
    {
        public int Stat()
        {
            Player Gladiator = new Player();
            int gDmg = Gladiator.TotalDmg;
            //Console.WriteLine((int)Gladiator.Strenght);
            return gDmg;
        }

    }
}

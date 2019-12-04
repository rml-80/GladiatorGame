using System;
using System.Collections.Generic;
using System.Text;

// create strenght and health
// create opponent , strenght and health
namespace Gladiator_Game
{
    class Fighters
    {
        public int GladiatorHP { set; get; }
        public int GladiatorStr { set; get; }
        public int EnemyHP { set; get; }
        public int EnemyStr { set; get; }
        private Random rnd = new Random();


        public void Gladiator()
        {
            GladiatorHP = rnd.Next(10, 20);
            GladiatorStr = rnd.Next(10, 20);
        }

        public void Enemy()
        {
            EnemyHP = rnd.Next(5, GladiatorHP);
            EnemyStr = rnd.Next(5, GladiatorStr);

        }
    }
}



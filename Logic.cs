using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightArena
{
    class Logic
    {
        public static Random rnd = new Random();
        public static int random(int lowest, int highest)
        {
            return rnd.Next(lowest, highest + 1);
        }
    }
}

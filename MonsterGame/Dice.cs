using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    public static class Dice
    {
        private static Random random = new Random();

        public static int ThrowDice()
        {
           return random.Next(1,7);
        }

        public static int ThrowDice(int diceType)
        {
            return random.Next(1, diceType + 1);
        }
    }
}

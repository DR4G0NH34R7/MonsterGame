using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    public class MonsterEasy
    {
        protected int damage = 10;

        public virtual void Attack(Player player)
        {
            DisplayAction.MonsterAttack(damage);
            int MonsterThrow = Dice.ThrowDice();
            int PlayerThrow = Dice.ThrowDice();
            if (MonsterThrow > PlayerThrow)
                player.TakesDamage(damage);
        }

        public bool IsAlive { get; private set; }

        public MonsterEasy()
        {
            IsAlive = true;
        }

        public void TakesDamage()
        {
            IsAlive = false;
        }
    }
}

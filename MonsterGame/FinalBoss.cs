using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    public class FinalBoss
    {
        protected DisplayAction display = new DisplayAction(true);
        public int HP { get; private set; }
        public bool IsAlive
        {
            get { return HP > 0; }
        }

        public FinalBoss(int points)
        {
            HP = points;
        }

        public void Attack(Player player)
        {
            int damageValue = Dice.ThrowDice(25);
            display.BossAttack(damageValue);
            player.TakesDamage(damageValue);
        }

        public void TakesDamage(int value)
        {
            HP -= value;
            display.BossHPLeft(HP);
        }
    }
}

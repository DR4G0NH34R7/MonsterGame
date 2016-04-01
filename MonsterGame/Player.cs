using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    public class Player
    {
        public int HP { get; private set; }
        public bool IsAlive { get { return HP > 0; } }

        public void Attack(MonsterEasy monster)
        {
            int MonsterThrow = Dice.ThrowDice();
            int PlayerThrow = Dice.ThrowDice();
            if (PlayerThrow >= MonsterThrow)
                monster.TakesDamage();
        }

        public void Attack(FinalBoss boss)
        {
            int attackValue = Dice.ThrowDice(25);
            DisplayAction.PlayerAttackVSBoss(attackValue);
            boss.TakesDamage(attackValue);
        }

        public void TakesDamage(int damage)
        {
            if (!Blocked())
            {
                HP -= damage;
                DisplayAction.HPLeft(HP);
            }
            else
                DisplayAction.DamageBlocked();
        }

        private bool Blocked()
        {
            return Dice.ThrowDice() <= 2;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Player"/>.
        /// </summary>
        public Player()
        {
            HP = 150;
        }

        public Player(int setHP)
        {
            HP = setHP;
        }
    }
}

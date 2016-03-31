using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    public class MonsterHard : MonsterEasy
    {
        protected int spellDamage = 5;

        public override void Attack(Player player)
        {
            base.Attack(player);
            if (player.IsAlive)
                Spell(player);

        }

        public void Spell(Player player)
        {
            int crit = Dice.ThrowDice();
            if (crit != 6)
            {
                display.SpellCast(crit, spellDamage);
                player.TakesDamage(crit * spellDamage);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonsterGame
{
    public class DisplayAction
    {
        public bool AutoScrollOption { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="DisplayAction"/>
        /// </summary>
        public DisplayAction()
        {
            AutoScrollOption = false;
        }

        public DisplayAction(bool AutoScrollSet)
        {
            AutoScrollOption = AutoScrollSet;
        }

        public void Menu()
        {
            Console.Clear();
            Console.WriteLine("Please select game mode :");
            Console.WriteLine("\t1 : Monsters");
            Console.WriteLine("\t2 : Final boss");
        }

        public void NewGame()
        {
            Console.WriteLine("New game started. You have 150 HP.");
            Scroll();
        }

        public void MonsterEncounter()
        {
            Console.WriteLine("You have encountered a monster!");
            Scroll();
        }

        public void PlayerAttack()
        {
            Console.WriteLine("You attack the monster.");
            Scroll();
        }

        public void PlayerAttackVSBoss(int damage)
        {
            Console.WriteLine("You attack for {0} damage!", damage);
            Scroll();
        }

        public void FailedPlayerAttack()
        {
            Console.WriteLine("You failed your attack. The monster strikes back!");
            Scroll();
        }

        public void HitBySpell(int damage, int multiplier)
        {
            Console.WriteLine("You are hit by a spell for {0} damage!", damage * multiplier);
            Scroll();
        }

        public void HPLeft(int hp)
        {
            Console.WriteLine("HP left: " + hp);
            Scroll();
        }

        public void BossHPLeft(int hp)
        {
            Console.WriteLine("Boss HP left: " + hp);
            Scroll();
        }

        public void DamageBlocked()
        {
            Console.WriteLine("You blocked the damage with your shield!");
            Scroll();
        }

        public void MonsterAttack(int damage)
        {
            Console.WriteLine("The monster attacks for {0} damage!", damage);
            Scroll();
        }

        public void SpellCast(int crit, int spellDamage)
        {
            Console.WriteLine("The monster casts a level {0} spell for {1} damage!", crit, crit * spellDamage);
            Scroll();
        }

        public void BossAttack(int damage)
        {
            Console.WriteLine("The boss attacks you for {0} damage!", damage);
            Scroll();
        }

        public void MonsterKilled()
        {
            Console.WriteLine("You kill the monster!");
            Scroll();
        }

        public void PlayerDeath()
        {
            Console.WriteLine("u ded :(");
            Scroll();
        }

        public void EndGame(int easyKills, int hardKills)
        {
            int score = easyKills + 2 * hardKills;
            Console.WriteLine("You have achieved {0} easy kills and {1} hard kills for a total score of {2} points!", easyKills, hardKills, score);
            Scroll();
        }

        public void BossVanquished()
        {
            CenterText("Congratulations! You saved the princess (or the prince)!");
            Scroll();
        }

        public void GameOver()
        {
            Console.Clear();
            CenterText("Game Over");
            Scroll();
        }

        private void Scroll()
        {
            if (AutoScrollOption)
                Thread.Sleep((int)TimeSpan.FromSeconds(0.5).TotalMilliseconds);
            else
                Console.ReadKey();
        }

        private static void CenterText(string text)
        {
            int spaces = (Console.WindowWidth - text.Length) / 2;
            int newLines = (Console.WindowHeight) / 2;
            Console.SetCursorPosition(spaces, newLines);
            Console.WriteLine(text);
        }
    }
}

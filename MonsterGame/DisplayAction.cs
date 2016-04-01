using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonsterGame
{
    public static class DisplayAction
    {
        private static bool autoScrollOptionValue = false;
        public static bool AutoScrollOption
        {
            get
            {
                return autoScrollOptionValue;
            }
            set
            {
                autoScrollOptionValue = value;
            }
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Please select game mode :");
            Console.WriteLine("\t1 : Monsters");
            Console.WriteLine("\t2 : Final boss");
        }

        public static void NewGame()
        {
            Console.WriteLine("New game started. You have 150 HP.");
            Scroll();
        }

        public static void MonsterEncounter()
        {
            Console.WriteLine("You have encountered a monster!");
            Scroll();
        }

        public static void PlayerAttack()
        {
            Console.WriteLine("You attack the monster.");
            Scroll();
        }

        public static void PlayerAttackVSBoss(int damage)
        {
            Console.WriteLine("You attack for {0} damage!", damage);
            Scroll();
        }

        public static void FailedPlayerAttack()
        {
            Console.WriteLine("You failed your attack. The monster strikes back!");
            Scroll();
        }

        public static void HPLeft(int hp)
        {
            Console.WriteLine("HP left: " + hp);
            Scroll();
        }

        public static void BossHPLeft(int hp)
        {
            Console.WriteLine("Boss HP left: " + hp);
            Scroll();
        }

        public static void DamageBlocked()
        {
            Console.WriteLine("You blocked the damage with your shield!");
            Scroll();
        }

        public static void MonsterAttack(int damage)
        {
            Console.WriteLine("The monster attacks for {0} damage!", damage);
            Scroll();
        }

        public static void SpellCast(int crit, int spellDamage)
        {
            Console.WriteLine("The monster casts a level {0} spell for {1} damage!", crit, crit * spellDamage);
            Scroll();
        }

        public static void BossAttack(int damage)
        {
            Console.WriteLine("The boss attacks you for {0} damage!", damage);
            Scroll();
        }

        public static void MonsterKilled()
        {
            Console.WriteLine("You kill the monster!");
            Scroll();
        }

        public static void PlayerDeath()
        {
            Console.WriteLine("u ded :(");
            Scroll();
        }

        public static void EndGame(int easyKills, int hardKills)
        {
            int score = easyKills + 2 * hardKills;
            Console.WriteLine("You have achieved {0} easy kills and {1} hard kills for a total score of {2} points!", easyKills, hardKills, score);
            Scroll();
        }

        public static void BossVanquished()
        {
            CenterText("Congratulations! You saved the princess (or the prince)!");
            Scroll();
        }

        public static void GameOver()
        {
            Console.Clear();
            CenterText("Game Over");
            Scroll();
        }

        private static void Scroll()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayAction.AutoScrollOption = true;
            DisplayAction.Menu();
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            while (consoleKeyInfo.Key != ConsoleKey.D1 && consoleKeyInfo.Key != ConsoleKey.D2 && consoleKeyInfo.Key != ConsoleKey.NumPad1 && consoleKeyInfo.Key != ConsoleKey.NumPad2)
            {
                DisplayAction.Menu();
                consoleKeyInfo = Console.ReadKey(true);
            }
            if (consoleKeyInfo.Key == ConsoleKey.D1 || consoleKeyInfo.Key == ConsoleKey.NumPad1)
                GameMode1();
            else
                GameMode2();
        }

        private static void GameMode1()
        {
            int playerHP = 150;
            Player player = new Player(playerHP);
            DisplayAction.NewGame();

            int easyKills = 0;
            int hardKills = 0;

            while (player.IsAlive)
            {
                MonsterEasy monster = SpawnMonster();
                DisplayAction.MonsterEncounter();
                while (monster.IsAlive)
                {
                    player.Attack(monster);
                    DisplayAction.PlayerAttack();
                    if (monster.IsAlive)
                    {
                        DisplayAction.FailedPlayerAttack();
                        monster.Attack(player);
                        if (!player.IsAlive)
                            break;
                    }
                    else
                    {
                        DisplayAction.MonsterKilled();
                        if (monster is MonsterHard)
                            hardKills++;
                        else
                            easyKills++;
                    }
                }
            }
            DisplayAction.PlayerDeath();

            DisplayAction.EndGame(easyKills, hardKills);
            Console.ReadKey();
        }

        private static void GameMode2()
        {
            Player player = new Player(150);
            FinalBoss boss = new FinalBoss(250);
            while (player.IsAlive && boss.IsAlive)
            {
                player.Attack(boss);
                if (boss.IsAlive)
                    boss.Attack(player);
            }
            if (player.IsAlive)
            {
                DisplayAction.AutoScrollOption = false;
                DisplayAction.BossVanquished();
            }
            else
            {
                DisplayAction.AutoScrollOption = false;
                DisplayAction.GameOver();
            }
        }

        private static MonsterEasy SpawnMonster()
        {
            if (Dice.ThrowDice(2) == 2)
                return new MonsterHard();
            else
                return new MonsterEasy();
        }
    }
}

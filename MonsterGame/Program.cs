using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGame
{
    class Program
    {
        private static DisplayAction display = new DisplayAction(true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            display.Menu();
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
            while (consoleKeyInfo.Key != ConsoleKey.D1 && consoleKeyInfo.Key != ConsoleKey.D2 && consoleKeyInfo.Key != ConsoleKey.NumPad1 && consoleKeyInfo.Key != ConsoleKey.NumPad2)
            {
                display.Menu();
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
            display.NewGame();

            int easyKills = 0;
            int hardKills = 0;

            while (player.IsAlive)
            {
                MonsterEasy monster = SpawnMonster();
                display.MonsterEncounter();
                while (monster.IsAlive)
                {
                    player.Attack(monster);
                    display.PlayerAttack();
                    if (monster.IsAlive)
                    {
                        display.FailedPlayerAttack();
                        monster.Attack(player);
                        if (!player.IsAlive)
                            break;
                    }
                    else
                    {
                        display.MonsterKilled();
                        if (monster is MonsterHard)
                            hardKills++;
                        else
                            easyKills++;
                    }
                }
            }
            display.PlayerDeath();

            display.EndGame(easyKills, hardKills);
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
                display.AutoScrollOption = false;
                display.BossVanquished();
            }
            else
            {
                display.AutoScrollOption = false;
                display.GameOver();
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

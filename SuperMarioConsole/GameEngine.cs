using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SuperMarioConsole
{
    static class GameEngine
    {
        [DllImport("user32.dll")]
        static extern short GetKeyState(int key);

        const int ConsoleWidth = 120;
        const int ConsoleHeight = 30;

        const int left = 0x25;
        const int up = 0x26;
        const int right = 0x27;
        const int keyPressed = 0x8000;

        private static int delay = 10;

        public static void Menu()
        {
            int MenuItemSelected = 0;
            DrawEngine.DrawMenu(MenuItemSelected);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        if (MenuItemSelected > 0)
                        {
                            MenuItemSelected--;
                            DrawEngine.DrawMenu(MenuItemSelected);
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if(MenuItemSelected < 2)
                        {
                            MenuItemSelected++;
                            DrawEngine.DrawMenu(MenuItemSelected);
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            switch (MenuItemSelected)
            {
                case 0:
                    Game();
                    break;
                case 1:
                    Settings();
                    break;
                case 2:
                    Exit();
                    break;
            }
        }
               
        public static void Game()
        {
            Player player = new Player();
            DrawEngine.DrawMap();
            DrawEngine.DrawPlayer(player);

            ExecuteControls(player);
        }

        public static void ExecuteControls(Player player)
        {
            while (true)
            {
                if ((GetKeyState(left) & keyPressed) > 0)
                {
                    player.MoveLeft();
                    Thread.Sleep(20);
                }
                if ((GetKeyState(right) & keyPressed) > 0)
                {
                    player.MoveRight();
                    Thread.Sleep(20);
                }
                if ((GetKeyState(up) & keyPressed) > 0)
                {
                    player.Jump();
                    Thread.Sleep(20);
                }
            }
        }

        public static void ExecuteControlsOnJump(Player player)
        {
            for (int i = 0; i < 6; i++)
            {
                if ((GetKeyState(left) & keyPressed) > 0)
                {
                    player.MoveLeft();
                    Thread.Sleep(20);
                }

                if ((GetKeyState(right) & keyPressed) > 0)
                {
                    player.MoveRight();
                    Thread.Sleep(20);
                }
            }
        }

        public static void GreetingA()
        {
            Console.Clear();
            DrawEngine.PrintAtPosition(55, 15, "Congradulations!");
            DrawEngine.PrintAtPosition(50, 17, "You have earned A!");
            Thread.Sleep(2000);
            Menu();
        }

        public static void GreetingE()
        {
            Console.Clear();
            DrawEngine.PrintAtPosition(55, 15, "We are sorry!");
            DrawEngine.PrintAtPosition(50, 17, "You have earned E!");
            Thread.Sleep(2000);
            Menu();
        }

        public static void Settings()
        {
            Console.Clear();
            Console.Write("Please, enter game delay in ms: ");
            delay = int.Parse(Console.ReadLine());
            Console.Write("Delay was changed to " + delay + " ms");
            Thread.Sleep(100);
            Menu();
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
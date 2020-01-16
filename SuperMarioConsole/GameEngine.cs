using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioConsole
{
    static class GameEngine
    {
        const int ConsoleWidth = 120;
        const int ConsoleHeight = 30;

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
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        player.MoveLeft();
                    }
                    if (keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        player.MoveRight();
                    }
                    if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        player.Jump();
                    }
                    else break;
                }
            }
        }

        public static void Settings()
        {
            //TODO
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
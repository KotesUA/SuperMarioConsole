using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioConsole
{
    class GameEngine
    {
        int MenuItemSelected { get; set; }
        const int ConsoleWidth = 120;
        const int ConsoleHeight = 30;

        public GameEngine()
        {
            MenuItemSelected = 0;
        }

        public void Menu()
        {
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
                    if (keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        if (MenuItemSelected < 2)
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

        public void Game()
        {
            Player player = new Player();
            DrawEngine.DrawMap();
            DrawEngine.DrawPlayer(player);
        }

        public void Settings()
        {
            //TODO
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
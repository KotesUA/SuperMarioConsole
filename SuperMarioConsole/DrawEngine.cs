using System;

namespace SuperMarioConsole
{
    static class DrawEngine
    {
        const int XMenu = 50;
        const int YMenu = 14;

        public static void PrintAtPosition(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        public static void DrawMenu(int selection)
        {
            Console.Clear();
            string[] menuItems = new string[3] { "Play", "Settings", "Exit game" };

            menuItems[selection] = "> " + menuItems[selection];

            PrintAtPosition(XMenu, YMenu, menuItems[0]);
            PrintAtPosition(XMenu, YMenu + 2, menuItems[1]);
            PrintAtPosition(XMenu, YMenu + 4, menuItems[2]);
        }

        public static void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    if (Map.mapArray[i][j] != ' ')
                    {
                        PrintAtPosition(j, i, Map.mapArray[i][j].ToString());
                    }
                }
            }
        }

        public static void DrawPlayer(Player player)
        {
            PrintAtPosition(player.positionX - 1, player.positionY - 1, player.playerImage[0]);
            PrintAtPosition(player.positionX - 1, player.positionY, player.playerImage[1]);
            PrintAtPosition(player.positionX - 1, player.positionY + 1, player.playerImage[2]);
        }

        public static void RemovePlayerAt(Player player)
        {
            PrintAtPosition(player.positionX - 1, player.positionY - 1, "   ");
            PrintAtPosition(player.positionX - 1, player.positionY, "   ");
            PrintAtPosition(player.positionX - 1, player.positionY + 1, "   ");
        }
    }
}
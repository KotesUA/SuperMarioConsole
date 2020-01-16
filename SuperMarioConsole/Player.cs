using System;

namespace SuperMarioConsole
{
    class Player
    {
        public int positionX { get; set; }
        public int positionY { get; set; }

        public Player()
        {
            positionX = 10;
            positionY = 27;
        }

        public void MoveLeft()
        {
            DrawEngine.RemovePlayerAt(this);
            positionX--;
            DrawEngine.DrawPlayer(this);
        }

        public void MoveRight()
        {
            DrawEngine.RemovePlayerAt(this);
            positionX++;
            DrawEngine.DrawPlayer(this);
        }

        public void Drop()
        {
            if (Map.mapArray[positionX - 1][positionY - 1] == ' '
                && Map.mapArray[positionX][positionY - 1] == ' '
                && Map.mapArray[positionX][positionY - 1] == ' '
                && positionY < 26)
            {
                DrawEngine.RemovePlayerAt(this);
                positionY++;
                DrawEngine.DrawPlayer(this);
            }
        }

        public void Jump()
        {
            int count = 0;
            while (count < 5)
            {
                if (Map.mapArray[positionX - 1][positionY + 1] == ' '
                    && Map.mapArray[positionX][positionY + 1] == ' '
                    && Map.mapArray[positionX][positionY + 1] == ' '
                    && positionY > 1)
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionY--;
                    DrawEngine.DrawPlayer(this);
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        if (positionX > 1)
                        {
                            if (Map.mapArray[positionY][positionX - 1] == ' '
                                && Map.mapArray[positionY - 1][positionX - 1] == ' '
                                && Map.mapArray[positionY + 1][positionX - 1] == ' ')
                            {
                                MoveLeft();
                            }
                        }
                    }
                    if (keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        if (positionX < 119)
                        {
                            if (Map.mapArray[positionY][positionX + 1] == ' '
                                && Map.mapArray[positionY - 1][positionX + 1] == ' '
                                && Map.mapArray[positionY + 1][positionX + 1] == ' ')
                            {
                                MoveRight();
                            }
                        }
                    }
                }
                count++;
            }
            Drop();
        }
    }
}
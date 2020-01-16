using System;
using System.Threading;

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
            if (positionX > 1)
            {
                if (Map.mapArray[positionY][positionX - 1] == ' '
                    && Map.mapArray[positionY - 1][positionX - 1] == ' '
                    && Map.mapArray[positionY + 1][positionX - 1] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX--;
                    DrawEngine.DrawPlayer(this);

                    Drop();
                }
            }
        }

        public void MoveRight()
        {
            if (positionX < 119)
            {
                if (Map.mapArray[positionY][positionX + 1] == ' '
                    && Map.mapArray[positionY - 1][positionX + 1] == ' '
                    && Map.mapArray[positionY + 1][positionX + 1] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX++;
                    DrawEngine.DrawPlayer(this);

                    Drop();
                }
            }
        }

        public void Drop()
        {
            while (true)
            {
                if (positionY < 26)
                {
                    if (Map.mapArray[positionY + 2][positionX - 1] == ' '
                        && Map.mapArray[positionY + 2][positionX] == ' '
                        && Map.mapArray[positionY + 2][positionX + 1] == ' ')
                    {
                        DrawEngine.RemovePlayerAt(this);
                        positionY++;
                        DrawEngine.DrawPlayer(this);
                    }
                }
                else break;
            }
        }

        public void Jump()
        {
            int count = 0;
            while (count < 5)
            {
                if (Map.mapArray[positionY - 2][positionX - 1] == ' '
                    && Map.mapArray[positionY - 2][positionX] == ' '
                    && Map.mapArray[positionY - 2][positionX + 1] == ' '
                    && positionY > 1)
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionY--;
                    DrawEngine.DrawPlayer(this);
                }
                Thread.Sleep(10);
                GameEngine.ExecuteControls(this);
                count++;
            }
            Drop();
        }
    }
}
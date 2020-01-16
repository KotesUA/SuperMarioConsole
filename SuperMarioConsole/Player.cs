using System;
using System.Threading;

namespace SuperMarioConsole
{
    class Player
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        private bool Dead;

        public Player()
        {
            positionX = 10;
            positionY = 27;
            Dead = false;
        }

        private void CheckDead()
        {
            if(Map.mapArray[positionY + 2][positionX - 1] == '*'
                    || Map.mapArray[positionY + 2][positionX + 1] == '*')
            {
                Dead = true;
            }
        }

        public void MoveLeft()
        {
            if (positionX > 1)
            {
                if (Map.mapArray[positionY][positionX - 2] == ' '
                    && Map.mapArray[positionY - 1][positionX - 2] == ' '
                    && Map.mapArray[positionY + 1][positionX - 2] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX--;
                    DrawEngine.DrawPlayer(this);
                }
            }
        }

        public void MoveRight()
        {
            if (positionX < 118)
            {
                if (Map.mapArray[positionY][positionX + 2] == ' '
                    && Map.mapArray[positionY - 1][positionX + 2] == ' '
                    && Map.mapArray[positionY + 1][positionX + 2] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX++;
                    DrawEngine.DrawPlayer(this);
                }
            }
        }

        public void Drop()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (positionY < 27)
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
                Thread.Sleep(200);

                GameEngine.ExecuteRightLeft(this);
                if (positionY > 1)
                {
                    if (Map.mapArray[positionY - 2][positionX - 1] == ' '
                        && Map.mapArray[positionY - 2][positionX] == ' '
                        && Map.mapArray[positionY - 2][positionX + 1] == ' ')
                    {
                        DrawEngine.RemovePlayerAt(this);
                        positionY--;
                        DrawEngine.DrawPlayer(this);
                    }
                    count++;
                }
            }
        }
    }
}
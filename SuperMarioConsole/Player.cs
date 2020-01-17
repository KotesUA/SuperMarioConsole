using System;
using System.Threading;

namespace SuperMarioConsole
{
    class Player
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        private bool midAir = false;

        public Player()
        {
            positionX = 5;
            positionY = 27;
        }

        public void MoveLeft()
        {
            if (positionX > 1)
            {
                if (Map.mapArray[positionY][positionX - 2] == ' '
                    && Map.mapArray[positionY + 1][positionX - 2] == '#')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionY--;
                    DrawEngine.DrawPlayer(this);
                }
                if (Map.mapArray[positionY][positionX - 2] == ' '
                    && Map.mapArray[positionY - 1][positionX - 2] == ' '
                    && Map.mapArray[positionY + 1][positionX - 2] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX--;
                    DrawEngine.DrawPlayer(this);
                }
                if (!midAir)
                {
                    Drop();
                }
            }
            SearchA();
            SearchE();
        }

        public void MoveRight()
        {
            if (positionX < 118)
            {
                if (Map.mapArray[positionY][positionX + 2] == ' '
                    && Map.mapArray[positionY + 1][positionX + 2] == '#')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionY--;
                    DrawEngine.DrawPlayer(this);
                }
                if (Map.mapArray[positionY][positionX + 2] == ' '
                    && Map.mapArray[positionY - 1][positionX + 2] == ' '
                    && Map.mapArray[positionY + 1][positionX + 2] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionX++;
                    DrawEngine.DrawPlayer(this);
                }
                if (!midAir)
                {
                    Drop();
                }
            }
            SearchA();
            SearchE();
        }

        public void Drop()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (Map.mapArray[positionY + 2][positionX - 1] == ' '
                    && Map.mapArray[positionY + 2][positionX] == ' '
                    && Map.mapArray[positionY + 2][positionX + 1] == ' ')
                {
                    DrawEngine.RemovePlayerAt(this);
                    positionY++;
                    DrawEngine.DrawPlayer(this);
                }
                else break;
            }
        }

        public void Jump()
        {
            midAir = true;
            int count = 0;
            while (count < 5)
            {
                Thread.Sleep(20);
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
                GameEngine.ExecuteControlsOnJump(this);
                GameEngine.ExecuteControlsOnJump(this);
                GameEngine.ExecuteControlsOnJump(this);
            }
            Drop();
        }

        public void SearchA()
        {
            if (Map.mapArray[positionY][positionX - 2] == 'A'
                    || Map.mapArray[positionY - 1][positionX - 2] == 'A'
                    || Map.mapArray[positionY + 1][positionX - 2] == 'A'
                    || Map.mapArray[positionY][positionX + 2] == 'A'
                    || Map.mapArray[positionY - 1][positionX + 2] == 'A'
                    || Map.mapArray[positionY + 1][positionX + 2] == 'A')
            {
                GameEngine.GreetingA();
            }
        }
        

        public void SearchE()
        {
            if (Map.mapArray[positionY][positionX - 2] == 'E'
                    || Map.mapArray[positionY - 1][positionX - 2] == 'E'
                    || Map.mapArray[positionY + 1][positionX - 2] == 'E'
                    || Map.mapArray[positionY][positionX + 2] == 'E'
                    || Map.mapArray[positionY - 1][positionX + 2] == 'E'
                    || Map.mapArray[positionY + 1][positionX + 2] == 'E')
            {
                GameEngine.GreetingE();
            }
        }
    }
}
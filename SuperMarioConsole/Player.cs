namespace SuperMarioConsole
{
    class Player
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public string[] playerImage;

        public Player()
        {
            positionX = 10;
            positionY = 27;
            playerImage = new string[]{" 0 ",
                                       "/|\\",
                                       "/ \\"};
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
    }
}
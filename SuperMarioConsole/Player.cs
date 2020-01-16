namespace SuperMarioConsole
{
    class Player
    {
        public int positionX { get; set; }
        public int positionY { get; set; }
        public string[] playerImage;

        public Player()
        {
            positionX = 60;
            positionY = 20;
            playerImage = new string[]{" 0 ",
                                       "/|\\",
                                       "/ \\"};
        }
    }
}
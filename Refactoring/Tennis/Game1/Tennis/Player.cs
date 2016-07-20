namespace Tennis.Tennis
{
    public class Player
    {
        private const int MaxUnderDeuce = 3;
        private const int Advantage = 1;
        private const int Win = 2;

        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Score { get; private set; }

        public void AddPoint() => Score++;

        public bool HasMinToDeuce() => Score >= MaxUnderDeuce;

        public bool HasPointScore() => Score <= MaxUnderDeuce;

        public bool HasAdvantage(Player player) => HasMinToDeuce() && player.HasMinToDeuce() && Score - player.Score == Advantage;

        public bool HasWon(Player otherPlayer) => !HasPointScore() && Score - otherPlayer.Score >= Win;
    }
}
namespace Tennis.Tennis
{
    public interface ITennisGame
    {
        void WonPoint(string playerName);
        string GetScore();
    }
}


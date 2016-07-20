namespace Tennis.Tennis.Format
{
    public class ScoreFormatter : IScoreFormatter
    {
        private const string All = "All";
        private const string Deuce = "Deuce";
        private const string Advantage = "Advantage ";
        private const string Win = "Win for ";
        private const string Separator = "-";

        readonly string[] _scores = { "Love", "Fifteen", "Thirty", "Forty" };

        public string FormatTie(Player player) => _scores[player.Score] + Separator + All;

        public string FormatPointScore(Player player, Player otherPlayer)
            => _scores[player.Score] + Separator + _scores[otherPlayer.Score];

        public string FormatDeuce() => Deuce;

        public string FormatAdvantage(Player player) => Advantage + player.Name;

        public string FormatWin(Player player) => Win + player.Name;
    }
}
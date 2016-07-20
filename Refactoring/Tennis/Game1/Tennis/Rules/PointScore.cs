using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    internal class PointScore : IRule
    {
        private readonly IScoreFormatter _formatter;

        public PointScore(IScoreFormatter formatter)
        {
            _formatter = formatter;
        }

        public bool Applies(Player player, Player otherPlayer)
            => player.HasPointScore() && otherPlayer.HasPointScore() && player.Score != otherPlayer.Score;

        public string Apply(Player player, Player otherPlayer)
        {
            return Applies(player, otherPlayer) ? _formatter.FormatPointScore(player, otherPlayer) : null;
        }
    }
}
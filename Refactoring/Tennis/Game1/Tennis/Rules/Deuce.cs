using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    internal class Deuce : IRule
    {
        private readonly IScoreFormatter _formatter;

        public Deuce(IScoreFormatter formatter)
        {
            _formatter = formatter;
        }

        private bool Applies(Player player, Player otherPlayer) => player.HasMinToDeuce() && player.Score == otherPlayer.Score;

        public string Apply(Player player, Player otherPlayer)
        {
            return Applies(player, otherPlayer) ? _formatter.FormatDeuce() : null;
        }
    }
}
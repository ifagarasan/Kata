using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    internal class Tie : IRule
    {
        private readonly IScoreFormatter _formatter;

        public Tie(IScoreFormatter formatter)
        {
            _formatter = formatter;
        }

        private bool Applies(Player player, Player otherPlayer)
            => !player.HasMinToDeuce() && player.Score == otherPlayer.Score;

        public string Apply(Player player, Player otherPlayer)
            => Applies(player, otherPlayer) ? _formatter.FormatTie(player) : null;
    }
}
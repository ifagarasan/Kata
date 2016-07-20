using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    internal class Advantage : IRule
    {
        private readonly IScoreFormatter _formatter;

        public Advantage(IScoreFormatter formatter)
        {
            _formatter = formatter;
        }

        private bool Applies(Player player, Player otherPlayer)
            => player.HasAdvantage(otherPlayer) || otherPlayer.HasAdvantage(player);

        public string Apply(Player player, Player otherPlayer)
            => Applies(player, otherPlayer) ? _formatter.FormatAdvantage(player.HasAdvantage(otherPlayer) ? player : otherPlayer) : null;
    }
}
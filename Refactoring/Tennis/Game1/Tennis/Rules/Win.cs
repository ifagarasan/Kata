using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    internal class Win : IRule
    {
        private readonly IScoreFormatter _formatter;

        public Win(IScoreFormatter formatter)
        {
            _formatter = formatter;
        }

        public bool Applies(Player player, Player otherPlayer) => player.HasWon(otherPlayer) || otherPlayer.HasWon(player);

        public string Apply(Player player, Player otherPlayer)
            => Applies(player, otherPlayer) ? _formatter.FormatWin(player.HasWon(otherPlayer) ? player : otherPlayer) : null;
    }
}
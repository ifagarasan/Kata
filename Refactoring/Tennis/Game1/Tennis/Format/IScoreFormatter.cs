namespace Tennis.Tennis.Format
{
    internal interface IScoreFormatter
    {
        string FormatTie(Player player);
        string FormatPointScore(Player player, Player otherPlayer);
        string FormatDeuce();
        string FormatAdvantage(Player player);
        string FormatWin(Player player);
    }
}
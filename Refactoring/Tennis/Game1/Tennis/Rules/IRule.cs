namespace Tennis.Tennis.Rules
{
    public interface IRule
    {
        string Apply(Player player, Player otherPlayer);
    }
}
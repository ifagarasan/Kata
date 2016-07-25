namespace TicTacToe.Board.Rule.Status
{
    public interface IRule
    {
        string Apply(IBoard board);
    }
}
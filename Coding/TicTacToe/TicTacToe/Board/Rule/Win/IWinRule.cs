using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Rule.Win
{
    internal interface IWinRule
    {
        Symbol? Apply(IBoard board);
    }
}
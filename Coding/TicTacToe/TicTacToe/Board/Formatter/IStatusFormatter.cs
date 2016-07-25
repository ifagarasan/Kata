using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Formatter
{
    public interface IStatusFormatter
    {
        string FormatStalemate();
        string FormatInProgress();
        string FormatWinner(Symbol winner);
    }
}
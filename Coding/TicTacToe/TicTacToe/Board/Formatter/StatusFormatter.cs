using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Formatter
{
    public class StatusFormatter : IStatusFormatter
    {
        public string FormatStalemate() => "Stalemate";

        public string FormatInProgress() => "In Progress";

        public string FormatWinner(Symbol winner) => $"Win for {winner}";
    }
}
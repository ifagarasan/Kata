using TicTacToe.Board.Formatter;

namespace TicTacToe.Board.Rule.Status
{
    internal class Stalemate : IRule
    {
        private readonly IStatusFormatter _formatter;

        public Stalemate(IStatusFormatter formatter)
        {
            _formatter = formatter;
        }

        public string Apply(IBoard board)
            => board.Full() && !board.HasWinner() ? _formatter.FormatStalemate() : string.Empty;
    }
}
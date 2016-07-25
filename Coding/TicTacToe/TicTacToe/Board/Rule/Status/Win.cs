using TicTacToe.Board.Formatter;

namespace TicTacToe.Board.Rule.Status
{
    public class Win : IRule
    {
        private readonly IStatusFormatter _formatter;

        public Win(IStatusFormatter formatter)
        {
            _formatter = formatter;
        }

        public string Apply(IBoard board) => board.HasWinner() ? _formatter.FormatWinner(board.Winner()) : string.Empty;
    }
}
using TicTacToe.Board.Formatter;

namespace TicTacToe.Board.Rule.Status
{
    internal class InProgress : IRule
    {
        private readonly IStatusFormatter _formatter;

        public InProgress(IStatusFormatter formatter)
        {
            _formatter = formatter;
        }

        public string Apply(IBoard board)
        {
            if (!board.HasWinner() && !board.Full())
                return _formatter.FormatInProgress();

            return string.Empty;
        }
    }
}
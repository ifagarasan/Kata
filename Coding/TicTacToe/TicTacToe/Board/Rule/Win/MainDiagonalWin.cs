using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Rule.Win
{
    internal class MainDiagonalWin : IWinRule
    {
        public Symbol? Apply(IBoard board)
        {
            var symbol = board.Retrieve(new Position(Index.One, Index.One)).Retrieve();
            if (symbol != Symbol.Empty && symbol == board.Retrieve(new Position(Index.Two, Index.Two)).Retrieve() &&
                symbol == board.Retrieve(new Position(Index.Three, Index.Three)).Retrieve())
                return symbol;

            return null;
        }
    }
}
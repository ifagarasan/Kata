using System;
using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Rule.Win
{
    internal class ColumnWin : IWinRule
    {
        public Symbol? Apply(IBoard board)
        {
            foreach (var column in Enum.GetValues(typeof(Index)))
            {
                var columnKey = (Index)column;

                var symbol = board.Retrieve(new Position(Index.One, columnKey)).Retrieve();
                if (symbol != Symbol.Empty)
                    if (symbol == board.Retrieve(new Position(Index.Two, columnKey)).Retrieve() &&
                        symbol == board.Retrieve(new Position(Index.Three, columnKey)).Retrieve())
                        return symbol;
            }

            return null;
        }
    }
}
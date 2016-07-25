using System;
using TicTacToe.Board.Cell;

namespace TicTacToe.Board.Rule.Win
{
    public class LineWin : IWinRule
    {
        public Symbol? Apply(IBoard board)
        {
            foreach (var row in Enum.GetValues(typeof(Index)))
            {
                var rowKey = (Index)row;

                var symbol = board.Retrieve(new Position(rowKey, Index.One)).Retrieve();
                if (symbol != Symbol.Empty)
                    if (symbol == board.Retrieve(new Position(rowKey, Index.Two)).Retrieve() &&
                        symbol == board.Retrieve(new Position(rowKey, Index.Three)).Retrieve())
                        return symbol;
            }

            return null;
        }
    }
}
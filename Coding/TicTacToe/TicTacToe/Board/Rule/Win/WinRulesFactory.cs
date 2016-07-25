using System.Collections.Generic;
using TicTacToe.Board.Formatter;
using TicTacToe.Board.Rule.Status;

namespace TicTacToe.Board.Rule.Win
{
    internal class WinRulesFactory
    {
        public static IEnumerable<IWinRule> Make()
        {
            return new IWinRule[]
            {
                new LineWin(),
                new ColumnWin(),
                new MainDiagonalWin(),
                new SecondaryDiagonalWin()
            };
        }
    }
}

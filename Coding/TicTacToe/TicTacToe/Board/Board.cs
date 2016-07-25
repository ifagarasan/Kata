using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TicTacToe.Board.Cell;
using TicTacToe.Board.Rule.Win;
using static TicTacToe.Board.Cell.Index;
using static TicTacToe.Board.Cell.Symbol;

namespace TicTacToe.Board
{
    public class Board : IBoard
    {
        private readonly IEnumerable<Cell.Cell> _cells;
        private readonly IEnumerable<IWinRule> _winRules;

        public Board()
        {
            _cells = MakeCells();
            _winRules = WinRulesFactory.Make();
        }

        public bool HasWinner() => Winner() != Empty;

        public void Mark(Position position, Symbol symbol) => Retrieve(position).Mark(symbol);

        public bool Full() => _cells.All(c => c.Retrieve() != Empty);

        public Symbol Winner()
        {
            return _winRules.Select(r => r.Apply(this)).SingleOrDefault(m => m.HasValue) ?? Empty;
        }

        public Cell.Cell Retrieve(Position position)
            => _cells.Single(l => l.Row() == position.Row() && l.Column() == position.Column());

        private static Cell.Cell[] MakeCells()
        {
            var cells = new Cell.Cell[9];

            var index = 0;

            foreach (var row in Enum.GetValues(typeof(Index)))
                foreach (var column in Enum.GetValues(typeof(Index)))
                    cells[index++] = new Cell.Cell((Index)row, (Index)column, Empty);

            return cells;
        }
    }
}
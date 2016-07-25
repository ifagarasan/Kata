using System.Collections.Generic;
using System.Linq;
using TicTacToe.Board.Cell;
using TicTacToe.Board.Formatter;
using TicTacToe.Board.Rule;
using TicTacToe.Board.Rule.Status;

namespace TicTacToe.Board
{
    public class Service
    {
        private readonly IEnumerable<IRule> _rules;

        public Service(IRulesFactory rulesFactory)
        {
            _rules = rulesFactory.Make();
        }

        public string Status(IBoard board) => Filter(Content(board));

        private static string Filter(IEnumerable<string> content) => content.Single(s => !string.IsNullOrEmpty(s));

        private IEnumerable<string> Content(IBoard board) => _rules.Select(r => r.Apply(board));
    }
}
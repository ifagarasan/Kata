using System.Collections.Generic;
using TicTacToe.Board.Formatter;

namespace TicTacToe.Board.Rule.Status
{
    public class RulesFactory: IRulesFactory
    {
        private readonly IStatusFormatter _formatter;

        public RulesFactory(IStatusFormatter formatter)
        {
            _formatter = formatter;
        }

        public IEnumerable<IRule> Make()
        {
            return new IRule[]
            {
                new Stalemate(_formatter),
                new InProgress(_formatter),
                new Win(_formatter)
            };
        }
    }
}

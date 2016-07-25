using System.Collections.Generic;

namespace TicTacToe.Board.Rule.Status
{
    public interface IRulesFactory
    {
        IEnumerable<IRule> Make();
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using Tennis.Tennis.Format;

namespace Tennis.Tennis.Rules
{
    public class RulesFactory
    {
        private static readonly IScoreFormatter Formatter = new ScoreFormatter();

        public static IEnumerable<IRule> Create() => new IRule[]
        {
            new Tie(Formatter),
            new PointScore(Formatter),
            new Deuce(Formatter),
            new Advantage(Formatter),
            new Win(Formatter), 
        };
    }
}
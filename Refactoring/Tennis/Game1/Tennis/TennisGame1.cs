using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Tennis.Tennis.Rules;

namespace Tennis.Tennis
{
    class TennisGame1 : ITennisGame
    {
        private readonly Player _player1;
        private readonly Player _player2;

        private readonly IEnumerable<IRule> _rules;

        public TennisGame1(string player1, string player2)
        {
            _rules = RulesFactory.Create();

            _player1 = new Player(player1);
            _player2 = new Player(player2);
        }

        public void WonPoint(string playerName)
        {
            var player = playerName.Equals(_player1.Name) ? _player1 : _player2;
            
            player.AddPoint();
        }

        public string GetScore() => MatchingRule(_rules.Select(r => r.Apply(_player1, _player2)));

        private static string MatchingRule(IEnumerable<string> results) => results.Single(r => !string.IsNullOrEmpty(r));
    }
}


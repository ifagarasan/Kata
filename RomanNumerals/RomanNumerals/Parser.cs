using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumerals
{
    public static class Parser
    {
        public static string Parse(int number)
        {
            return new NumeralRepresentation(number).ToString();
        }
    }

    internal class NumeralRepresentation
    {
        private readonly List<Numeral> _numerals;
        private int _lastAddedCharacterTypeCount;

        public NumeralRepresentation(int number)
        {
            _numerals = new List<Numeral>();

            var index = 0;
            while (number > 0)
            {
                var currentNumeral = NumeralNumberSystem.Numerals[index];
                if (currentNumeral.Value <= number)
                {
                    number -= currentNumeral.Value;
                    Add(currentNumeral);
                }
                else
                    index++;
            }
        }

        public void Add(Numeral numeral)
        {
            if (numeral.Value != _numerals.LastOrDefault()?.Value)
                _lastAddedCharacterTypeCount = 0;
            else if (_lastAddedCharacterTypeCount == 3)
            {
                _numerals.RemoveRange(_numerals.Count-3, 3);

                var last = _numerals.LastOrDefault();
                var ancestorTarget = numeral;

                if (NumeralNumberSystem.NextLargerThan(numeral).Value == last?.Value)
                {
                    ancestorTarget = last;
                    _numerals.Remove(last);
                }

                _numerals.Add(numeral);
                _numerals.Add(NumeralNumberSystem.NextLargerThan(ancestorTarget));
                _lastAddedCharacterTypeCount = 1;
                return;
            }

            _numerals.Add(numeral);
            _lastAddedCharacterTypeCount++;
        }

        public override string ToString()
        {
            return _numerals.Aggregate(string.Empty, (current, numeral) => $"{current}{numeral.Symbol}");
        }
    }

    internal class Numeral
    {
        public Numeral(int value, string symbol)
        {
            Value = value;
            Symbol = symbol;
        }

        public int Value { get; }

        public string Symbol { get; }
    }

    internal static class NumeralNumberSystem
    {
        private const string M = "M";
        private const string D = "D";
        private const string C = "C";
        private const string L = "L";
        private const string X = "X";
        private const string V = "V";
        private const string I = "I";

        private static readonly Numeral Thousand = new Numeral(1000, M);
        public static readonly Numeral FiveHundred = new Numeral(500, D);
        public static readonly Numeral Hundred = new Numeral(100, C);
        public static readonly Numeral Fifty = new Numeral(50, L);
        private static readonly Numeral Ten = new Numeral(10, X);
        private static readonly Numeral Five = new Numeral(5, V);
        private static readonly Numeral One = new Numeral(1, I);

        static readonly Dictionary<string, Numeral> NextLarger;

        private static readonly List<Numeral> _numerals;

        public static IList<Numeral> Numerals => _numerals.AsReadOnly();

        static NumeralNumberSystem()
        {
            _numerals = new List<Numeral>
            {
                Thousand,
                FiveHundred,
                Hundred,
                Fifty,
                Ten,
                Five,
                One
            };

            NextLarger = new Dictionary<string, Numeral>
            {
                { I, Five },
                { V, Ten },
                { X, Fifty },
                { L, Hundred },
                { C, FiveHundred },
                { D, Thousand }
            };
        }

        public static Numeral NextLargerThan(Numeral numeral) => NextLarger[numeral.Symbol];
    }
}

﻿using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public static class Parser
    {
        public static string Parse(int number)
        {
            var numeralRepresentation = new NumeralList();

            var index = 0;
            while (number > 0)
            {
                var currentNumeral = NumeralNumberSystem.Numerals[index];
                if (currentNumeral.Value <= number)
                {
                    number -= currentNumeral.Value;
                    numeralRepresentation.Add(currentNumeral);
                }
                else
                    index++;
            }

            return numeralRepresentation.ToString();
        }
    }

    internal class NumeralList
    {
        private readonly List<Numeral> _numerals;

        public NumeralList()
        {
            _numerals = new List<Numeral>();
        }

        public void Add(Numeral numeral)
        {
            if (CanAppendNumeral(numeral))
                _numerals.Add(numeral);
            else
            {
                _numerals.RemoveRange(_numerals.Count - 3, 3);

                var last = _numerals.LastOrDefault();
                var ancestorTarget = numeral;

                if (NumeralNumberSystem.ImmediateLarger(numeral).Value == last?.Value)
                {
                    ancestorTarget = last;
                    _numerals.Remove(last);
                }

                _numerals.Add(numeral);
                _numerals.Add(NumeralNumberSystem.ImmediateLarger(ancestorTarget));
            }   
        }

        private bool CanAppendNumeral(Numeral numeral)
        {
            if (_numerals.Count < 3)
                return true;

            for (var i = _numerals.Count - 3; i < _numerals.Count; ++i)
                if (_numerals[i] != numeral)
                    return true;

            return false;
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
        private static readonly Numeral Thousand = new Numeral(1000, "M");
        public static readonly Numeral FiveHundred = new Numeral(500, "D");
        public static readonly Numeral Hundred = new Numeral(100, "C");
        public static readonly Numeral Fifty = new Numeral(50, "L");
        private static readonly Numeral Ten = new Numeral(10, "X");
        private static readonly Numeral Five = new Numeral(5, "V");
        private static readonly Numeral One = new Numeral(1, "I");

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
        }

        public static Numeral ImmediateLarger(Numeral numeral) => Numerals[Numerals.IndexOf(numeral)-1];
    }
}

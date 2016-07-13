using System;

namespace parrot.Parrot.Type
{
    public class NorwegianBlue : ParrotType
    {
        private readonly bool _isNailed;
        private readonly double _voltage;

        public NorwegianBlue(double voltage, bool isNailed)
        {
            _isNailed = isNailed;
            _voltage = voltage;
        }

        public override double ComputeSpeed() => _isNailed ? 0 : Math.Min(24.0, _voltage*BaseSpeed);
    }
}
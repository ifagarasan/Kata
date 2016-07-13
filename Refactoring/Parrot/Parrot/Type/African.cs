using System;

namespace parrot.Parrot.Type
{
    public class African : ParrotType
    {
        private const double LoadFactor = 9.0;

        private readonly int _numberOfCoconuts;

        public African(int numberOfCoconuts)
        {
            _numberOfCoconuts = numberOfCoconuts;
        }

        public override double ComputeSpeed()
        {
            return Math.Max(0, BaseSpeed - LoadFactor * _numberOfCoconuts);
        }
    }
}
using System;
using parrot.Parrot.Type;

namespace parrot.Parrot
{
    public class Parrot
    {
        private readonly ParrotType _parrotType;

        public Parrot(ParrotType parrotType)
        {
            _parrotType = parrotType;
        }

        public double GetSpeed() => _parrotType.ComputeSpeed();
    }
}

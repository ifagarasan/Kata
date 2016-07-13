using System;

namespace parrot.Parrot.Type
{
    public class European : ParrotType
    {
        public override double ComputeSpeed() => BaseSpeed;
    }
}
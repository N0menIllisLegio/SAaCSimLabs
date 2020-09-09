using System;
using System.Collections.Generic;
using System.Text;

namespace SAaCSimLabs.Generators
{
    class GammaGenerator : MLCG
    {
        public GammaGenerator(int seed, int multiplier, int modulus, int increment = 0) : base(seed, multiplier, modulus, increment)
        {
        }

        public override double NextNumber()
        {
            return base.NextNumber();
        }
    }
}

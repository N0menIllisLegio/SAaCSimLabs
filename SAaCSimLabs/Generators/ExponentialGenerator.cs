using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class ExponentialGenerator : MLCG
    {
        private readonly List<double> _sequence;

        public double Lambda { get; }
        public override double[] Sequence => _sequence.ToArray();

        public ExponentialGenerator(decimal lambda, int seed, int multiplier, int modulus, int increment = 0) 
            : base(seed, multiplier, modulus, increment)
        {
            Lambda = (double) lambda;
            _sequence = new List<double>();
        }

        public override double NextNumber()
        {
            double value = -1 / Lambda * Math.Log(base.NextNumber());
            _sequence.Add(value);
            return value;
        }
    }
}

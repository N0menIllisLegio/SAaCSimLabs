using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class GaussGenerator : MLCG
    {
        private readonly Random _rnd = new Random();
        private readonly List<double> _sequence = new List<double>();

        public int N { get; }
        public double StandardDeviation { get; }
        public double ExpectedValue { get; }

        public override double[] Sequence => _sequence.ToArray();

        public GaussGenerator(decimal n, decimal expectedValue, decimal standardDeviation, int count, 
            int seed, int multiplier, int modulus, int increment = 0) : base(seed, multiplier, modulus, increment)
        {
            N = (int) n;
            StandardDeviation = (double) standardDeviation;
            ExpectedValue = (double) expectedValue;

            for (int i = 0; i < count; i++)
            {
                base.NextNumber();
            }
        }

        public override double NextNumber()
        {
            double randomSum = 0;

            for (int i = 0; i < N; i++)
            {
                randomSum += base.Sequence[_rnd.Next(Sequence.Length)];
            }

            double value = ExpectedValue + StandardDeviation * Math.Sqrt(12D / N) * (randomSum - N / 2D);
            _sequence.Add(value);

            return value;
        }
    }
}

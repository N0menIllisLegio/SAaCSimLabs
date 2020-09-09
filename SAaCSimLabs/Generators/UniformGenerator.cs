using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class UniformGenerator : MLCG
    {
        private readonly List<double> _sequence = new List<double>();

        public double A { get; }
        public double B { get; }

        public override double[] Sequence => _sequence.ToArray();

        public UniformGenerator(decimal a, decimal b, int seed, int multiplier, int modulus, int increment = 0) 
            : base(seed, multiplier, modulus, increment)
        {
            A = (double) a;
            B = (double) b;
        }

        public override double NextNumber()
        {
            double value = A + (B - A) * base.NextNumber();
            _sequence.Add(value);
            return value;
        }
    }
}

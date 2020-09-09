using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class SimpsonGenerator : IGenerator
    {
        private readonly List<double> _sequence = new List<double>();
        private readonly Random _rnd = new Random();
        private readonly double[] _intervalRandoms;

        public double A { get; }
        public double B { get; }

        public double[] Sequence => _sequence.ToArray();

        public SimpsonGenerator(decimal a, decimal b, int count, MLCG genMLCG)
        {
            A = (double) a;
            B = (double) b;
            _intervalRandoms = new double[count];

            for (int i = 0; i < count; i++)
            {
                _intervalRandoms[i] = (A / 2) + (B / 2 - A / 2) * genMLCG.NextNumber();
            }
        }

        public double NextNumber()
        {
            double result = _intervalRandoms[_rnd.Next(_intervalRandoms.Length)] +
                            _intervalRandoms[_rnd.Next(_intervalRandoms.Length)];
            _sequence.Add(result);

            return result;
        }
    }
}

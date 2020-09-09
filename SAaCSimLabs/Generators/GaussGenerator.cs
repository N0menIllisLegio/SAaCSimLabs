using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class GaussGenerator : IGenerator
    {
        private readonly Random _rnd = new Random();
        private readonly List<double> _sequence = new List<double>();
        private readonly MLCG _generatorMLCG;

        public int N { get; }
        public double StandardDeviation { get; }
        public double ExpectedValue { get; }

        public double[] Sequence => _sequence.ToArray();

        public GaussGenerator(decimal n, decimal expectedValue, decimal standardDeviation, int count, MLCG genMLCG)
        {
            N = (int) n;
            StandardDeviation = (double) standardDeviation;
            ExpectedValue = (double) expectedValue;
            _generatorMLCG = genMLCG;

            for (int i = 0; i < count; i++)
            {
                _generatorMLCG.NextNumber();
            }
        }

        public double NextNumber()
        {
            double randomSum = 0;

            for (int i = 0; i < N; i++)
            {
                randomSum += _generatorMLCG.Sequence[_rnd.Next(_generatorMLCG.Sequence.Length)];
            }

            double result = ExpectedValue + StandardDeviation * Math.Sqrt(12D / N) * (randomSum - N / 2D);
            _sequence.Add(result);

            return result;
        }
    }
}

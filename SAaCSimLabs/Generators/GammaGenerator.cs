using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class GammaGenerator : IGenerator
    {
        private readonly List<double> _sequence = new List<double>();
        private readonly Random _rnd = new Random();
        private readonly MLCG _generatorMLCG;

        public int Eta { get; }
        public double Lambda { get; }
        public double[] Sequence => _sequence.ToArray();

        public GammaGenerator(decimal eta, decimal lambda, int count, MLCG genMLCG)
        {
            Eta = (int) eta;
            Lambda = (double) lambda;
            _generatorMLCG = genMLCG;

            for (int i = 0; i < count; i++)
            {
                _generatorMLCG.NextNumber();
            }
        }

        public double NextNumber()
        {
            double multiplication = 1;

            for (int i = 0; i < Eta; i++)
            {
                multiplication *= _generatorMLCG.Sequence[_rnd.Next(_generatorMLCG.Sequence.Length)];
            }

            double result = -1 / Lambda * Math.Log(multiplication);
            _sequence.Add(result);

            return result;
        }
    }
}

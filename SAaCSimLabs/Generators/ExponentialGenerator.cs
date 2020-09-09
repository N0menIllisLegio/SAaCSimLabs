using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class ExponentialGenerator : IGenerator
    {
        private readonly List<double> _sequence = new List<double>();
        private readonly MLCG _generatorMLCG;

        public double Lambda { get; }
        public double[] Sequence => _sequence.ToArray();

        public ExponentialGenerator(decimal lambda, MLCG genMLCG)
        {
            Lambda = (double) lambda;
            _generatorMLCG = genMLCG;
        }

        public double NextNumber()
        {
            double result = -1 / Lambda * Math.Log(_generatorMLCG.NextNumber());
            _sequence.Add(result);
            return result;
        }
    }
}

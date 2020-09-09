using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class UniformGenerator : IGenerator
    {
        private readonly MLCG _generatorMLCG;
        private readonly List<double> _sequence = new List<double>();

        public double A { get; }
        public double B { get; }

        public double[] Sequence => _sequence.ToArray();

        public UniformGenerator(decimal a, decimal b, MLCG genMLCG)
        {
            A = (double) a;
            B = (double) b;
            _generatorMLCG = genMLCG;
        }

        public double NextNumber()
        {
            double result = A + (B - A) * _generatorMLCG.NextNumber();
            _sequence.Add(result);
            return result;
        }
    }
}

using System;
using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class TriangularGenerator : IGenerator
    {
        private readonly List<double> _sequence = new List<double>();
        private readonly Random _rnd = new Random();
        private readonly MLCG _generatorMLCG;

        public double A { get; }
        public double B { get; }
        public bool UsingMin { get; }

        public double[] Sequence => _sequence.ToArray();

        public TriangularGenerator(decimal a, decimal b, bool isMin, int count, MLCG genMLCG)
        {
            A = (double) a;
            B = (double) b;
            UsingMin = isMin;
            _generatorMLCG = genMLCG;

            for (int i = 0; i < count; i++)
            {
                _generatorMLCG.NextNumber();
            }
        }

        public double NextNumber()
        {
            double n1 = _generatorMLCG.Sequence[_rnd.Next(_generatorMLCG.Sequence.Length)],
                   n2 = _generatorMLCG.Sequence[_rnd.Next(_generatorMLCG.Sequence.Length)];

            double result = UsingMin
                ? A + (B - A) * Math.Min(n1, n2)
                : A + (B - A) * Math.Max(n1, n2);

            _sequence.Add(result);
            return result;
        }
    }
}

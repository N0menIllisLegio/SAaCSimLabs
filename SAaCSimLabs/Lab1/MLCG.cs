using System.Collections.Generic;

namespace SAaCSimLabs.Lab1
{
    class MLCG
    {
        private int _prevNumber;
        private readonly List<double> _sequence;

        public double Seed { get; }
        public int A { get; }
        public int M { get; }
        public int C { get; }
        public double[] Sequence => _sequence.ToArray();

        public MLCG(int seed, int a, int m, int c = 0)
        {
            _prevNumber = seed;
            A = a;
            M = m;
            C = c;
            Seed = seed;

            _sequence = new List<double>();
        }

        public double NextNumber()
        {
            _prevNumber = (int) (((long) A * _prevNumber + C) % M);
            double generatedNumber = _prevNumber / (double) M;
            _sequence.Add(generatedNumber); 
            
            return generatedNumber;
        }
    }
}
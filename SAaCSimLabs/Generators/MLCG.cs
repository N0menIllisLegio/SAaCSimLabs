﻿using System.Collections.Generic;

namespace SAaCSimLabs.Generators
{
    class MLCG : IGenerator
    {
        private int _prevNumber;
        private readonly List<double> _sequence;

        public double Seed { get; }
        public int Multiplier { get; }
        public int Modulus { get; }
        public int Increment { get; }
        public virtual double[] Sequence => _sequence.ToArray();

        public MLCG(int seed, int multiplier, int modulus, int increment = 0)
        {
            _prevNumber = seed;
            Multiplier = multiplier;
            Modulus = modulus;
            Increment = increment;
            Seed = seed;

            _sequence = new List<double>();
        }

        public virtual double NextNumber()
        {
            _prevNumber = (int) (((long) Multiplier * _prevNumber + Increment) % Modulus);
            double generatedNumber = _prevNumber / (double) Modulus;
            _sequence.Add(generatedNumber); 
            
            return generatedNumber;
        }


    }
}
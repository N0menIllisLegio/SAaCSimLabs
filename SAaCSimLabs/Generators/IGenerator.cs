namespace SAaCSimLabs.Generators
{
    interface IGenerator
    {
        public double Seed { get; }
        public int Multiplier { get; }
        public int Modulus { get; }
        public int Increment { get; }

        public double[] Sequence { get; }

        public double NextNumber();
    }
}

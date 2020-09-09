namespace SAaCSimLabs.Generators
{
    interface IGenerator
    {
        public double[] Sequence { get; }

        public double NextNumber();
    }
}

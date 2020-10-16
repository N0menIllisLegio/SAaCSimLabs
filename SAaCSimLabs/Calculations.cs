using SAaCSimLabs.Generators;
using ScottPlot;
using System;
using System.Linq;

namespace SAaCSimLabs
{
    class Calculations
    {
        private readonly double[] _sequence;
        private readonly double _plotMin;
        private readonly double _plotMax;

        public double ExpectedValue { get; private set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public int Period { get; private set; }
        public int AperiodicitySegment { get; private set; }

        public Calculations(MLCG generator)
        {
            _sequence = generator.Sequence;
            CalculateStatistics();
            _plotMin = 0;
            _plotMax = 1;

            CalculatePeriodAndAperiodicitySegment(generator.Multiplier, generator.Modulus, generator.Increment);
        }

        public Calculations(IGenerator generator)
        {
            _sequence = generator.Sequence;
            CalculateStatistics();
            _plotMin = _sequence.Min();
            _plotMax = _sequence.Max();
        }

        private void CalculateStatistics()
        {
            ExpectedValue = Statistics.ExpectedValue(_sequence);
            Variance = Statistics.Variance(_sequence, ExpectedValue);
            StandardDeviation = Statistics.StandardDeviation(Variance);
        }

        public void BuildHistogram(Plot plt)
        {
            const int barsCount = 20;
            double low = _plotMin;
            double delta = (_plotMax - low) / barsCount;
            double high = low + delta;

            double[] numbersInIntervals = new double[barsCount];
            double[] xs = new double[barsCount];
            string[] labels = new string[barsCount];

            for (int i = 0; i < barsCount; i++)
            {
                numbersInIntervals[i] = _sequence.Count(value => value >= low && value < high);
                xs[i] = i;
                labels[i] = $"{low:F2} - {high:F2}";

                low += delta;
                high += delta;
            }

            plt.PlotBar(xs, numbersInIntervals, showValues: true);
            plt.XTicks(xs, labels);

            plt.Ticks(xTickRotation: 45);
            plt.Grid(enableVertical: false, lineStyle: LineStyle.Dot);
            plt.XLabel(" ", fontSize: 40);
        }

        public double EstimateDistributionEvenness()
        {
            int length = _sequence.Length % 2 == 0 ? _sequence.Length : _sequence.Length - 1;
            int k = 0;

            for (int i = 0; i < length; i++)
            {
                if (Math.Pow(_sequence[i], 2) + Math.Pow(_sequence[++i], 2) < 1)
                {
                    k++;
                }
            }

            return 2 * k / (double) length;
        }

        private void CalculatePeriodAndAperiodicitySegment(int a, int m, int c)
        {
            // Period
            double lastNumber = _sequence.Last();
            int i1 = Array.FindIndex(_sequence, number => IsEquals(number, lastNumber)),
                i2 = Array.FindIndex(_sequence, i1 == _sequence.Length - 1 ? i1 : i1 + 1, number => IsEquals(number, lastNumber));

            Period = i2 - i1;

            if (Period == 0)
            {
                AperiodicitySegment = 0;
                return;
            }

            // Aperiodicity Segment
            //MLCG lcpRng = new MLCG((int) Math.Round(_sequence[Period - 1] * m), a, m, c);

            //for (int i = 0; i < _sequence.Length; i++)
            //{
            //    if (IsEquals(_sequence[i], lcpRng.NextNumber()))
            //    {
            //        AperiodicitySegment = i + Period;
            //        return;
            //    }
            //}

            // ! NOT 100% SURE !
            AperiodicitySegment = _sequence.Length % Period + Period;
        }

        private bool IsEquals(double value1, double value2)
        {
            const double difference = .0000000000000001;

            return Math.Abs(value1 - value2) <= difference;
        }
    }
}

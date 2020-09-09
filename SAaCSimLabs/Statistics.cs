using System;
using System.Linq;

namespace SAaCSimLabs
{
    public static class Statistics
    {
        // Математическое ожидание
        public static double ExpectedValue(double[] values)
        {
             return values.Sum() / values.Length;
        }

        // Дисперсия
        public static double Variance(double[] values)
        {
            double expectedValue = ExpectedValue(values);
            return Variance(values, expectedValue);
        }

        public static double Variance(double[] values, double expectedValue)
        {
            return values.Sum(value => Math.Pow(value - expectedValue, 2)) / (values.Length - 1);
        }

        // Среднеквадратическое отклонение
        public static double StandardDeviation(double[] values)
        {
            return Math.Sqrt(Variance(values));
        }

        public static double StandardDeviation(double[] values, double expectedValue)
        {
            return Math.Sqrt(Variance(values, expectedValue));
        }

        public static double StandardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }
    }
}

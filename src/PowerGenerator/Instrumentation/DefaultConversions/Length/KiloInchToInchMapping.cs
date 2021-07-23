using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class KiloInchToInchMapping : IMapping
    {
        public Unit Left => KiloInch;

        public Unit Right => Inch;

        private const decimal Value = 1000m;

        public decimal ConvertToRight(decimal value)
        {
            return value * Value;
        }

        public decimal ConvertToLeft(decimal value)
        {
            return value / Value;
        }
    }
}

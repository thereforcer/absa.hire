using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class KilometerToMeterMapping : IMapping
    {
        public Unit Left => Kilometer;

        public Unit Right => Meter;

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

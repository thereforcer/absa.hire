using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class InchToMeterMapping : IMapping
    {
        public Unit Left => Inch;

        public Unit Right => Meter;

        private const decimal Value = 0.0254m;

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

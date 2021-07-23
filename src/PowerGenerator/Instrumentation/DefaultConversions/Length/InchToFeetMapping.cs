using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class InchToFeetMapping : IMapping
    {
        public Unit Left => Inch;

        public Unit Right => Feet;

        private const decimal Value = 12;

        public decimal ConvertToRight(decimal value)
        {
            return value / Value;
        }

        public decimal ConvertToLeft(decimal value)
        {
            return value * Value;
        }
    }
}

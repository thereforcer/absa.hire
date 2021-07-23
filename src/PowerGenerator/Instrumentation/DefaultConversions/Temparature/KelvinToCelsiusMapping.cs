using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class KelvinToCelsiusMapping : IMapping
    {
        public Unit Left => Kelvin;

        public Unit Right => Celsius;

        private const decimal Value = 273.15m;

        public decimal ConvertToRight(decimal value)
        {
            return value - Value;
        }

        public decimal ConvertToLeft(decimal value)
        {
            return value + Value;
        }
    }
}
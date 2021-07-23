using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class FahrenheitToCelsiusMapping : IMapping
    {
        public Unit Left => Fahrenheit;

        public Unit Right => Celsius;

        public decimal ConvertToRight(decimal value)
        {
            return (value - 32) * 5 / 9;
        }

        public decimal ConvertToLeft(decimal value)
        {
            return (value * 9 / 5) + 32;
        }
    }
}
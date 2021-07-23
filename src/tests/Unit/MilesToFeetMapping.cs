using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    internal class MilesToFeetMapping : IMapping
    {
        public Unit Left => new Mile();

        public Unit Right => Feet;

        private const decimal Value = 5280;

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
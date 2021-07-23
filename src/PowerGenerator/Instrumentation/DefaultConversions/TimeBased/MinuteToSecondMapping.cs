using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class MinuteToSecondMapping : IMapping
    {
        public Unit Left => Minute;

        public Unit Right => Second;

        private const decimal Value = 60;

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
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class HourToMinuteMapping : IMapping
    {
        public Unit Left => Hour;

        public Unit Right => Minute;

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
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class MebiByteToKibiByteMapping : IMapping
    {
        public Unit Left => MebiByte;

        public Unit Right => KibiByte;

        private const decimal Value = 1024;

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
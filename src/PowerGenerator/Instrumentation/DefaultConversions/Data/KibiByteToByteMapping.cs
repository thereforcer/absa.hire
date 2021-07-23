using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class KibiByteToByteMapping : IMapping
    {
        public Unit Left => KibiByte;

        public Unit Right => Byte;

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
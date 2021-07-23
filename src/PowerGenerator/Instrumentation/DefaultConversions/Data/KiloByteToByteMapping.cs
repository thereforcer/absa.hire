using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class KiloByteToByteMapping : IMapping
    {
        public Unit Left => KiloByte;

        public Unit Right => Byte;

        private const decimal Value = 1000;

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
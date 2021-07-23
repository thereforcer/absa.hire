using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class MegaByteToKiloByteMapping : IMapping
    {
        public Unit Left => MegaByte;

        public Unit Right => KiloByte;

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
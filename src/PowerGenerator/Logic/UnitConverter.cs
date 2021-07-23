// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Logic
{
    internal sealed class UnitConverter : IUnitConverter
    {
        private readonly ConversionConfiguration _configuration;

        public UnitConverter(ConversionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public decimal Convert(decimal value, Unit destination, Unit source)
        {
            var conversionPath = _configuration.FindConversionPath(source, destination);
            return conversionPath.Convert(value);
        }
    }
}

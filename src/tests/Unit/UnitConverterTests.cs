using Absa.Hire.Newbies.PowerConverter.Logic;
using Xunit;
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class UnitConverterTests
    {
        [Fact]
        public void Convert_UnknownMapping_Failure()
        {
            // ARRANGE
            var converter = new UnitConverter(new ConversionConfiguration());

            // ACT
            var exception = Assert.Throws<MappingNotFoundException>(() => converter.Convert(1m, Second, Hour));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Cannot find mapping from \"hour\" to \"second\".", exception.Message);
        }

        [Fact]
        public void Convert_TwoRequestOneFromCache_Ok()
        {
            // ARRANGE
            var configuration = new ConversionConfiguration();
            configuration.AddMapping(new HourToMinuteMapping());
            var converter = new UnitConverter(configuration);

            // ACT
            var value1 = converter.Convert(1m, Minute, Hour);
            var value2 = converter.Convert(1m, Minute, Hour);

            // ASSERT
            Assert.Equal(60m, value1);
            Assert.Equal(60m, value2);
        }
    }
}

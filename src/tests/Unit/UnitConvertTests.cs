using System;
using System.Globalization;
using Xunit;
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class UnitConvertTests
    {
        [Fact]
        public void ConvertUnit_NewUnitNewMappingFromMilesToKilometer_Ok()
        {
            // ARRANGE

            // ACT
            UnitConvert.Settings.Conversion.AddMapping(new MilesToFeetMapping());
            var value = UnitConvert.Convert(1m, Kilometer, new Mile());

            // ASSERT
            Assert.Equal(1.609344m, value);
        }

        [Fact]
        public void ConvertUnit_InvalidKilometerToSecond_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<InvalidOperationException>(() => UnitConvert.Convert(1m, Second, Kilometer));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Cannot convert units in different categories (length vs time).", exception.Message);
        }

        [Fact]
        public void ConvertUnit_ValidKilometerToFeet_Ok()
        {
            // ARRANGE

            // ACT
            var value = UnitConvert.Convert(1m, Feet, Kilometer);

            // ASSERT
            Assert.Equal(3280.83m, (decimal)(int)(value * 100)/100);
        }

        [Fact]
        public void ConvertUnit_ValidKilometerToMeter_Ok()
        {
            // ARRANGE

            // ACT
            var value = UnitConvert.Convert(1m, Meter, Kilometer);

            // ASSERT
            Assert.Equal(1000m, value);
        }

        [Fact]
        public void ConvertText_ValidTextInput_Ok()
        {
            // ARRANGE
            const string input = "1 km";
            const string expectedUnit = "feets";

            // ACT
            UnitConvert.Settings.Parser.CultureInfo = CultureInfo.InvariantCulture;
            var result = UnitConvert.Convert(input, expectedUnit);

            // ASSERT
            Assert.Equal("3280.8398950131233595800524934 feet", result);
        }

        [Fact]
        public void ConvertText_TaskExample1_Ok()
        {
            // ARRANGE
            // ACT
            UnitConvert.Settings.Parser.CultureInfo = CultureInfo.InvariantCulture;
            var result = UnitConvert.Convert("1 meter", "feet");

            // ASSERT
            Assert.StartsWith("3.28", result);
            Assert.EndsWith(" feet", result);
        }

        [Fact]
        public void ConvertText_TaskExample2_Ok()
        {
            // ARRANGE
            // ACT
            UnitConvert.Settings.Parser.CultureInfo = CultureInfo.InvariantCulture;
            var result = UnitConvert.Convert("3 kiloinches", "meter");

            // ASSERT
            Assert.Equal("76.2000 meter", result);
        }

        [Fact]
        public void ConvertText_NewUnitNewMappingFromMilesToKilometer_Ok()
        {
            // ARRANGE

            // ACT
            var settings = new UnitConvertSettings();
            settings.Conversion.AddMapping(new MilesToFeetMapping());
            settings.Parser.AddUnit(new Mile());
            settings.Parser.CultureInfo = new CultureInfo("cs-CZ");
            var value = UnitConvert.Convert("1 mile", "km", settings);

            // ASSERT
            Assert.Equal("1,609344 kilometer", value);
        }

        [Fact]
        public void ConvertText_NullInput_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<ArgumentNullException>(() => UnitConvert.Convert(null, "km"));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Value cannot be null. (Parameter 'input')", exception.Message);
        }

        [Fact]
        public void ConvertText_NullExpectedUnit_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<ArgumentNullException>(() => UnitConvert.Convert("1 m", null));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Value cannot be null. (Parameter 'expectedUnit')", exception.Message);
        }

        [Fact]
        public void ConvertText_TaskExample3_Ok()
        {
            // ARRANGE
            // ACT
            UnitConvert.Settings.Parser.CultureInfo = CultureInfo.InvariantCulture;
            var result = UnitConvert.Convert("1 MiB", "bytes");

            // ASSERT
            Assert.Equal("1048576 byte", result);
        }

        [Fact]
        public void ConvertText_TaskExample4_Ok()
        {
            // ARRANGE
            // ACT
            UnitConvert.Settings.Parser.CultureInfo = CultureInfo.InvariantCulture;
            var result = UnitConvert.Convert("1 K", "°F");

            // ASSERT
            Assert.Equal("-457.87 fahrenheit", result);
        }
    }
}

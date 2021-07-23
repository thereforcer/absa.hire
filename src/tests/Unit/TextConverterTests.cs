using System;
using Absa.Hire.Newbies.PowerConverter.Logic;
using NSubstitute;
using Xunit;
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class TextConverterTests
    {
        [Fact]
        public void Convert_ValidRequest_Ok()
        {
            // ARRANGE
            var parserConfiguration = new ParserConfiguration();
            parserConfiguration.AddUnit(Meter);
            parserConfiguration.AddUnit(Kilometer);
            var unitConverter = Substitute.For<IUnitConverter>();
            unitConverter.Convert(1m, Meter, Kilometer).Returns(8m);
            var textConverter = new TextConverter(parserConfiguration, unitConverter);

            // ACT
            var value = textConverter.Convert("1 km", "meter");

            // ASSERT
            Assert.Equal("8 meter", value);
        }

        [Fact]
        public void Convert_InvalidInput_Failure()
        {
            // ARRANGE
            var parserConfiguration = new ParserConfiguration();
            var unitConverter = Substitute.For<IUnitConverter>();
            var textConverter = new TextConverter(parserConfiguration, unitConverter);

            // ACT
            var exception = Assert.Throws<FormatException>(() => textConverter.Convert("tutan", "meter"));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Expected two tokens like \"[value] [unit]\".", exception.Message);
        }

        [Fact]
        public void Convert_NotNumberInput_Failure()
        {
            // ARRANGE
            var parserConfiguration = new ParserConfiguration();
            var unitConverter = Substitute.For<IUnitConverter>();
            var textConverter = new TextConverter(parserConfiguration, unitConverter);

            // ACT
            var exception = Assert.Throws<FormatException>(() => textConverter.Convert("my meter", "meter"));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Value \"my\" must be a number.", exception.Message);
        }
    }
}

using System;
using Absa.Hire.Newbies.PowerConverter.API;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.ImperialUnits;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.SI;
using Xunit;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class ConversionConfigurationTests
    {
        [Fact]
        public void AddMapping_NullObject_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<ArgumentNullException>(() => UnitConvert.Settings.Conversion.AddMapping(null));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Value cannot be null. (Parameter 'mapping')", exception.Message);
        }

        [Fact]
        public void AddMapping_NullLeftUnit_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<ArgumentNullException>(() => UnitConvert.Settings.Conversion.AddMapping(new InternalTestMapping(null, new Feet())));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Left unit not specified. (Parameter 'Left')", exception.Message);
        }

        [Fact]
        public void AddMapping_NullRightUnit_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<ArgumentNullException>(() => UnitConvert.Settings.Conversion.AddMapping(new InternalTestMapping(new Meter(), null)));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Right unit not specified. (Parameter 'Right')", exception.Message);
        }

        [Fact]
        public void AddMapping_SameUnitMapping_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<InvalidOperationException>(() => UnitConvert.Settings.Conversion.AddMapping(new InternalTestMapping(new Meter(), new Meter())));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Cannot convert from/to same unit.", exception.Message);
        }

        [Fact]
        public void AddMapping_DifferentUnitCatagoriesMapping_Failure()
        {
            // ARRANGE

            // ACT
            var exception = Assert.Throws<InvalidOperationException>(() => UnitConvert.Settings.Conversion.AddMapping(new InternalTestMapping(new Meter(), new Second())));

            // ASSERT
            Assert.NotNull(exception);
            Assert.Equal("Cannot convert units in different categories (length vs time).", exception.Message);
        }

        private class InternalTestMapping : IMapping
        {
            public InternalTestMapping(Unit left, Unit right)
            {
                Left = left;
                Right = right;
            }

            public Unit Left { get; }

            public Unit Right { get; }

            public decimal ConvertToRight(decimal value)
            {
                throw new NotSupportedException();
            }

            public decimal ConvertToLeft(decimal value)
            {
                throw new NotSupportedException();
            }
        }
    }
}

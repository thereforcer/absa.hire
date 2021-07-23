using Absa.Hire.Newbies.PowerConverter.Primitives.Categories;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.SI;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.TimeBased;
using Xunit;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class UnitTests
    {
        [Fact]
        public void Equals_SameOrDiffUnit_Ok()
        {
            // ARRANGE
            var second = new Second();
            var meter1 = new Meter();
            var meter2 = new Meter();
            var kilometer = new Kilometer();

            // ACT
            var false1 = second.Equals(meter1);
            var true1 = meter1.Equals(meter2);
            var false2 = meter2.Equals(kilometer);

            // ASSERT
            Assert.False(false1);
            Assert.True(true1);
            Assert.False(false2);
        }

        [Fact]
        public void Equals_SameOrDiffCategory_Ok()
        {
            // ARRANGE
            var length1 = new LengthCategory();
            var length2 = new LengthCategory();
            var time = new TimeCategory();
            var speed = new SpeedCategory();

            // ACT
            var true1 = length1.Equals(length2);
            var false1 = length1.Equals(time);
            var false2 = length2.Equals(speed);

            // ASSERT
            Assert.True(true1);
            Assert.False(false1);
            Assert.False(false2);
        }
    }
}

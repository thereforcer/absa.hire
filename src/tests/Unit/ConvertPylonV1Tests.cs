using System.Globalization;
using Absa.Hire.Newbies.Functions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class ConvertPylonV1Tests
    {
        [Fact]
        public void Invoke_ValidRequest_Ok200()
        {
            // ARRANGE
            const decimal inputValue = 1m;
            const string inputUnit = "hour";
            const string expectedUnit = "second";
            const string expectedResult = "3600 second";
            var logger = Substitute.For<ILogger>();
            var textConverter = Substitute.For<ITextConverter>();
            textConverter.Convert($"{inputValue} {inputUnit}", expectedUnit).Returns(expectedResult);
            var pylon = new ConvertPylonV1(logger, textConverter);

            // ACT
            var result = pylon.InternalInvoke(logger, inputValue.ToString(CultureInfo.InvariantCulture), inputUnit, expectedUnit) as OkObjectResult;

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }

        [Fact]
        public void Invoke_InvalidUnit_BadRequest400()
        {
            // ARRANGE
            const decimal inputValue = 1m;
            const string inputUnit = "glass";
            const string expectedUnit = "second";
            const string expectedResult = "Cannot find unit \"glass\".";
            var logger = Substitute.For<ILogger>();
            var textConverter = Substitute.For<ITextConverter>();
            textConverter.Convert($"{inputValue} {inputUnit}", expectedUnit).Throws(new UnitNotFoundException("glass"));
            var pylon = new ConvertPylonV1(logger, textConverter);

            // ACT
            var result = pylon.InternalInvoke(logger, inputValue.ToString(CultureInfo.InvariantCulture), inputUnit, expectedUnit) as BadRequestObjectResult;

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(expectedResult, result.Value);
        }
    }
}

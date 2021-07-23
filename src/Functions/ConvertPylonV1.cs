using System;
using Absa.Hire.Newbies.PowerConverter;
using Absa.Hire.Newbies.PowerConverter.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.Functions
{
    public sealed class ConvertPylonV1
    {
        internal ConvertPylonV1(ILogger logger = null, ITextConverter textConverter = null)
        {
            _logger = logger;
            _textConverter = textConverter;
        }

        private ILogger _logger;
        private ITextConverter _textConverter;

        [FunctionName("ConvertV1")]
        public static IActionResult Invoke([HttpTrigger(AuthorizationLevel.Anonymous, "GET", Route = "convert/v1/{value}/{unit}/to/{expectedUnit}")]HttpRequest request, ILogger logger, string value, string unit, string expectedUnit)
        {
            var instance = new ConvertPylonV1();
            return instance.InternalInvoke(logger, value, unit, expectedUnit);
        }

        internal IActionResult InternalInvoke(ILogger logger, string value, string unit, string expectedUnit)
        {
            var settings = new UnitConvertSettings();
            _textConverter ??= new TextConverter(settings.Parser, new UnitConverter(settings.Conversion));
            _logger = logger;

            try
            {
                var input = $"{value} {unit}";
                _logger.LogInformation($"Calling Convert({input}, {expectedUnit}).");
                var result = _textConverter.Convert(input, expectedUnit);

                _logger.LogInformation($"Call Convert({input}, {expectedUnit}) = {result}");
                return new OkObjectResult(result);
            }
            catch (UnitNotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
            catch (FormatException ex)
            {
                _logger.LogWarning(ex, ex.Message);
                return new BadRequestObjectResult(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected exception. {ex.Message}");
                throw;
            }
        }
    }
}

using System;
using System.Globalization;
using System.Linq;

namespace Absa.Hire.Newbies.PowerConverter.Logic
{
    internal sealed class TextConverter : ITextConverter
    {
        private readonly ParserConfiguration _configuration;
        private readonly IUnitConverter _converter;

        internal TextConverter(ParserConfiguration configuration, IUnitConverter converter)
        {
            _configuration = configuration;
            _converter = converter;
        }

        /// <exception cref="UnitNotFoundException"/>
        /// <exception cref="MappingNotFoundException"/>
        public string Convert(string input, string expectedUnit)
        {
            var(value, sourceUnit) = ParseInput(input);
            var destinationUnit = _configuration.FindUnitByText(expectedUnit);
            var result = _converter.Convert(value, destinationUnit, sourceUnit);
            return $"{result.ToString(_configuration.CultureInfo)} {destinationUnit.UnitName}";
        }

        /// <exception cref="UnitNotFoundException"/>
        private(decimal value, Unit unit) ParseInput(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (tokens.Count != 2)
            {
                throw new FormatException($"Expected two tokens like \"[value] [unit]\".");
            }

            if (!decimal.TryParse(tokens[0], NumberStyles.Any, _configuration.CultureInfo, out var value))
            {
                throw new FormatException($"Value \"{tokens[0]}\" must be a number.");
            }

            var unit = _configuration.FindUnitByText(tokens[1].Trim());
            return (value, unit);
        }
    }
}

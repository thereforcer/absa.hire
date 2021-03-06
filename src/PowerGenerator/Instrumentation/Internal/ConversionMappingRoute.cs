using System;
using System.Collections.Generic;
using System.Linq;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class ConversionMappingRoute : SimplifiedMapping
    {
        private ConversionMappingRoute(Unit source, Unit destination, IReadOnlyCollection<ISimpleMapping> mappings) : base(source, destination, value => InternalConvert(value, mappings))
        {
        }

        public static decimal InternalConvert(decimal value, IReadOnlyCollection<ISimpleMapping> mappings)
        {
            var result = value;
            foreach (var mapping in mappings)
            {
                result = mapping.Convert(result);
            }

            return result;
        }

        public static ConversionMappingRoute Create(IReadOnlyList<ISimpleMapping> mappings)
        {
            VerifyPath(mappings);
            var source = mappings.First().Source;
            var destination = mappings.Last().Destination;
            return new ConversionMappingRoute(source, destination, mappings);
        }

        private static void VerifyPath(IReadOnlyList<ISimpleMapping> mappings)
        {
            if (mappings.Count >= 2)
            {
                for (var i = 1; i <= mappings.Count - 1; i++)
                {
                    var outputUnitMappingLeft = mappings[i - 1].Destination;
                    var inputUnitMappingRight = mappings[i].Source;
                    if (!outputUnitMappingLeft.Equals(inputUnitMappingRight))
                    {
                        throw new InvalidOperationException("Conversion Path is invalid.");
                    }
                }
            }
        }
    }
}

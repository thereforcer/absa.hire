using System;
using Absa.Hire.Newbies.PowerConverter.Logic;
using JetBrains.Annotations;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter
{
    /// <summary>
    /// = API for UnitConvert =
    /// </summary>
    public static class UnitConvert
    {
        static UnitConvert()
        {
            Settings = new UnitConvertSettings();
        }

        public static UnitConvertSettings Settings { get; set; }

        /// <summary>
        /// Converts value in source unit to destination unit.
        /// </summary>
        /// <exception cref="MappingNotFoundException"/>
        public static decimal Convert(decimal value, [NotNull]Unit destination, [NotNull]Unit source, UnitConvertSettings settings = null)
        {
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            settings ??= Settings;

            var unitConverter = CreateUnitConverter(settings);
            return unitConverter.Convert(value, destination, source);
        }

        /// <summary>
        /// Converts input value unit phrase into destination unit phrase.
        /// </summary>
        /// <exception cref="UnitNotFoundException"/>
        /// <exception cref="MappingNotFoundException"/>
        public static string Convert([NotNull] string input, [NotNull]string expectedUnit, UnitConvertSettings settings = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrEmpty(expectedUnit))
            {
                throw new ArgumentNullException(nameof(expectedUnit));
            }

            settings ??= Settings;

            var unitConverter = CreateUnitConverter(settings);
            var textConverter = new TextConverter(settings.Parser, unitConverter);
            return textConverter.Convert(input, expectedUnit);
        }

        private static IUnitConverter CreateUnitConverter(UnitConvertSettings settings)
        {
            var converter = new UnitConverter(settings.Conversion);
            return converter;
        }
    }
}

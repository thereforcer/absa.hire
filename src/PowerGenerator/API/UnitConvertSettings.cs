using Absa.Hire.Newbies.PowerConverter.Logic;
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter
{
    public sealed class UnitConvertSettings
    {
        public UnitConvertSettings()
        {
            Parser = new ParserConfiguration();
            Parser.AddUnit(Feet);
            Parser.AddUnit(Inch);
            Parser.AddUnit(Yard);
            Parser.AddUnit(Meter);
            Parser.AddUnit(Second);
            Parser.AddUnit(Minute);
            Parser.AddUnit(Hour);
            Parser.AddUnit(Byte);
            Parser.AddUnit(KiloByte);
            Parser.AddUnit(KibiByte);
            Parser.AddUnit(MegaByte);
            Parser.AddUnit(MebiByte);
            Parser.AddUnit(Celsius);
            Parser.AddUnit(Fahrenheit);
            Parser.AddUnit(Kelvin);

            // some basic default conversions
            Conversion = new ConversionConfiguration();
            Conversion.AddMapping(new InchToFeetMapping());
            Conversion.AddMapping(new InchToMeterMapping());
            Conversion.AddMapping(new HourToMinuteMapping());
            Conversion.AddMapping(new MinuteToSecondMapping());
            Conversion.AddMapping(new KiloByteToByteMapping());
            Conversion.AddMapping(new KibiByteToByteMapping());
            Conversion.AddMapping(new MegaByteToKiloByteMapping());
            Conversion.AddMapping(new MebiByteToKibiByteMapping());
            Conversion.AddMapping(new FahrenheitToCelsiusMapping());
            Conversion.AddMapping(new KelvinToCelsiusMapping());
        }

        public ConversionConfiguration Conversion { get; }

        public ParserConfiguration Parser { get; }
    }
}

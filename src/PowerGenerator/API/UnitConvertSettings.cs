using Absa.Hire.Newbies.PowerConverter.Logic;
using static Absa.Hire.Newbies.PowerConverter.WellknownUnits;

namespace Absa.Hire.Newbies.PowerConverter.API
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
            Parser.AddUnit(Kilometer);
            Parser.AddUnit(Second);

            // some basic default conversions
            Conversion = new ConversionConfiguration();
            Conversion.AddMapping(new KilometerToMeterMapping());
            Conversion.AddMapping(new InchToFeetMapping());
            Conversion.AddMapping(new InchToMeterMapping());
        }

        public ConversionConfiguration Conversion { get; }

        public ParserConfiguration Parser { get; }
    }
}

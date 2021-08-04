using Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.ImperialUnits;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.SI;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.TemperatureBased;
using Absa.Hire.Newbies.PowerConverter.Primitives.Units.TimeBased;

namespace Absa.Hire.Newbies.PowerConverter
{
    public static class WellknownUnits
    {
        // length
        public static readonly Unit Feet = new Feet();
        public static readonly Unit Inch = new Inch();
        public static readonly Unit Yard = new Yard();
        public static readonly Unit Meter = new Meter();

        // time-based
        public static readonly Unit Second = new Second();
        public static readonly Unit Minute = new Minute();
        public static readonly Unit Hour = new Hour();

        // data
        public static readonly Unit Byte = new Byte();
        public static readonly Unit KiloByte = new KiloByte();
        public static readonly Unit KibiByte = new KibiByte();
        public static readonly Unit MegaByte = new MegaByte();
        public static readonly Unit MebiByte = new MebiByte();

        // temperature
        public static readonly Unit Celsius = new Celsius();
        public static readonly Unit Fahrenheit = new Fahrenheit();
        public static readonly Unit Kelvin = new Kelvin();
    }
}

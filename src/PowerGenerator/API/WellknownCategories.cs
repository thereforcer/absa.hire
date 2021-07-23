using Absa.Hire.Newbies.PowerConverter.Primitives.Categories;

namespace Absa.Hire.Newbies.PowerConverter
{
    public static class WellknownCategories
    {
        public static readonly Category Length = new LengthCategory();
        public static readonly Category Time = new TimeCategory();
        public static readonly Category Speed = new SpeedCategory();
        public static readonly Category Data = new DataCategory();
        public static readonly Category Temperature = new TemperatureCategory();
    }
}

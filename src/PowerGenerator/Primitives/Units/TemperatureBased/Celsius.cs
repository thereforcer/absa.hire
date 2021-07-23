using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TemperatureBased
{
    public sealed class Celsius : Unit
    {
        public Celsius() : base(Guid.Parse("345d41a7-8e50-4d66-8b09-0744eb5ce915"), "celsius", Temperature)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("°C");
        }
    }
}
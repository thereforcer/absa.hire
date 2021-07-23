using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TemperatureBased
{
    public sealed class Fahrenheit : Unit
    {
        public Fahrenheit() : base(Guid.Parse("e287dca2-26ab-450c-b6c0-7c8c9f467559"), "fahrenheit", Temperature)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("°F");
        }
    }
}
using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TemperatureBased
{
    public sealed class Kelvin : Unit
    {
        public Kelvin() : base(Guid.Parse("bb203a86-b085-4d61-bd84-4f450bb0df22"), "kelvin", Temperature)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("K");
        }
    }
}
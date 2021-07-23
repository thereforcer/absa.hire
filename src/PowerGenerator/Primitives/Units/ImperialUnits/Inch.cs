using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.ImperialUnits
{
    public sealed class Inch : Unit
    {
        public Inch() : base(Guid.Parse("0bed018f-a6e9-4c6f-bf58-8bbfb3957c5f"), "inch", Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("inches");
        }
    }
}
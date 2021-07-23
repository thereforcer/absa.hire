using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.ImperialUnits
{
    public sealed class Yard : Unit
    {
        public Yard() : base(Guid.Parse("21c2906f-8051-4ce9-8b0b-fcf42151bd34"), "yard", Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("yards");
        }
    }
}
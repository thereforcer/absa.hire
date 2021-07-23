using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.ImperialUnits
{
    public sealed class Yard : Unit
    {
        public Yard() : base(Guid.Parse("21c2906f-8051-4ce9-8b0b-fcf42151bd34"), "yard", WellknownCategories.Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("yards");
        }
    }
}
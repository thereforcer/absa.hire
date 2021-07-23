using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.ImperialUnits
{
    public sealed class KiloInch : Unit
    {
        public KiloInch() : base(Guid.Parse("a71f3717-bacf-4266-8568-04a28de167f0"), "kiloinch", WellknownCategories.Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("kiloinches");
        }
    }
}
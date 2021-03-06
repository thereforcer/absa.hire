using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.ImperialUnits
{
    public sealed class Feet : Unit
    {
        public Feet() : base(Guid.Parse("ab0856b8-3b19-49f1-bbcc-b282cfd39994"), "feet", WellknownCategories.Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("feets");
        }
    }
}

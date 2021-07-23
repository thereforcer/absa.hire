using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.SI
{
    public sealed class Meter : Unit
    {
        public Meter() : base(Guid.Parse("e8ec5c76-37cc-4fa7-8d12-fb1030d0d776"), "meter", WellknownCategories.Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("m");
            collection.Add("meters");
        }
    }
}

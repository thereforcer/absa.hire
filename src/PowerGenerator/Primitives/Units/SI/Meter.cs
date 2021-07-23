using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.SI
{
    public sealed class Meter : Unit
    {
        public Meter() : base(Guid.Parse("e8ec5c76-37cc-4fa7-8d12-fb1030d0d776"), "meter", Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("m");
            collection.Add("meters");
        }
    }
}

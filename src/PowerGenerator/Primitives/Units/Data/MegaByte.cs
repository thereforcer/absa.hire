using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data
{
    public sealed class MegaByte : Unit
    {
        public MegaByte() : base(Guid.Parse("26e9e3e1-fb8c-4f6d-bed7-05400ac4c7df"), "megabyte", WellknownCategories.Data)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("MB");
            collection.Add("megabytes");
        }
    }
}
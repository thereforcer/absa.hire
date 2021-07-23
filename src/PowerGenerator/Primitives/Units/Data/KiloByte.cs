using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data
{
    public sealed class KiloByte : Unit
    {
        public KiloByte() : base(Guid.Parse("6ee5300d-6405-40a5-a93b-9f51bfff4bec"), "kilobyte", WellknownCategories.Data)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("kB");
            collection.Add("kilobytes");
        }
    }
}
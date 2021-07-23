using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data
{
    public sealed class Byte : Unit
    {
        public Byte() : base(Guid.Parse("837da5ea-a699-4ccc-99ff-62b1a2f85443"), "byte", WellknownCategories.Data)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("B");
            collection.Add("bytes");
        }
    }
}
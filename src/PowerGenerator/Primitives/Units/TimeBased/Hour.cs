using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TimeBased
{
    public sealed class Hour : Unit
    {
        public Hour() : base(Guid.Parse("b37967bf-7765-47e2-8c80-86c1f35f0431"), "hour", Time)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("h");
            collection.Add("hours");
        }
    }
}
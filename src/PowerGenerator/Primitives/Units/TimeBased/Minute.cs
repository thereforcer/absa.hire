using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TimeBased
{
    public sealed class Minute : Unit
    {
        public Minute() : base(Guid.Parse("9f1fb13e-0263-46fe-b405-993aa802180f"), "minute", Time)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("min");
            collection.Add("minutes");
        }
    }
}
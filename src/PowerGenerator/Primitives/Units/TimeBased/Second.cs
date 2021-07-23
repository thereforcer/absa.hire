using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.TimeBased
{
    public sealed class Second : Unit
    {
        public Second() : base(Guid.Parse("394e7381-5e46-415b-a6e1-489f9af3339e"), "second", Time)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("s");
            collection.Add("seconds");
        }
    }
}
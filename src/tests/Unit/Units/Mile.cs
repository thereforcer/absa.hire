using System;
using System.Collections.Generic;
using static Absa.Hire.Newbies.PowerConverter.WellknownCategories;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.UnitTests
{
    public sealed class Mile : Unit
    {
        public Mile() : base(Guid.Parse("a54e2b68-3fbb-4174-bf03-edeb75bb505e"), "mile", Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("miles");
        }
    }
}
using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data
{
    public sealed class MebiByte : Unit
    {
        public MebiByte() : base(Guid.Parse("431ed027-fc37-4104-becc-1a7475f20d48"), "mebibyte", WellknownCategories.Data)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("MiB");
            collection.Add("mebibytes");
        }
    }
}
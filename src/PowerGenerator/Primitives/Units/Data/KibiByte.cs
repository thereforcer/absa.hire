using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Data
{
    public sealed class KibiByte : Unit
    {
        public KibiByte() : base(Guid.Parse("f90d3eee-ef2d-4e24-8422-a4fa46c7bd41"), "kibibyte", WellknownCategories.Data)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("KiB");
            collection.Add("kibibytes");
        }
    }
}
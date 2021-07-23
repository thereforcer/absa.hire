﻿using System;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Units.Length.SI
{
    public sealed class Kilometer : Unit
    {
        public Kilometer() : base(Guid.Parse("3fc7ab2d-79e1-4ef4-a3cd-d3cfbdb209ab"), "kilometer", WellknownCategories.Length)
        {
        }

        protected override void RegisterOtherUnitName(IList<string> collection)
        {
            collection.Add("km");
        }
    }
}
using System;
// ReSharper disable UnusedMember.Global

namespace Absa.Hire.Newbies.PowerConverter.Primitives.Categories
{
    public sealed class DataCategory : Category
    {
        public DataCategory() : base(Guid.Parse("00000000-bbbb-0000-bbbb-111111111111"), "data")
        {
        }
    }
}

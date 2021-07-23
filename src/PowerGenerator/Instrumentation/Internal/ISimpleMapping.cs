using System;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal interface ISimpleMapping : IEquatable<ISimpleMapping>
    {
        Unit Source { get; }

        Unit Destination { get; }

        decimal Convert(decimal value);
    }
}

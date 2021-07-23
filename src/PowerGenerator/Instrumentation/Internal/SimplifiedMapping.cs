using System;
using System.Diagnostics;

namespace Absa.Hire.Newbies.PowerConverter
{
    internal class SimplifiedMapping : ISimpleMapping, IEquatable<SimplifiedMapping>
    {
        internal SimplifiedMapping(Unit source, Unit destination, Func<decimal, decimal> callback)
        {
            Source = source;
            Destination = destination;

            _callback = callback;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Func<decimal, decimal> _callback;

        public Unit Source { get; }

        public Unit Destination { get; }

        public decimal Convert(decimal value)
        {
            return _callback(value);
        }

        bool IEquatable<ISimpleMapping>.Equals(ISimpleMapping other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Source, other.Source) && Equals(Destination, other.Destination);
        }

        public override string ToString()
        {
            return $"{Source}->{Destination}";
        }

        public bool Equals(SimplifiedMapping other)
        {
            return ((IEquatable<ISimpleMapping>)this).Equals(other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((SimplifiedMapping) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Source != null ? Source.GetHashCode() : 0) * 397) ^ (Destination != null ? Destination.GetHashCode() : 0);
            }
        }
    }
}

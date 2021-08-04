using System;
using System.Collections.Generic;
using System.Diagnostics;

#pragma warning disable S4035
namespace Absa.Hire.Newbies.PowerConverter
{
    public abstract class Unit : IEquatable<Unit>
    {
        protected Unit(Guid unitId, string unitName, Category category)
        {
            UnitId = unitId;
            UnitName = unitName;
            Category = category;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal Guid UnitId { get; }

        public string UnitName { get; }

        public Category Category { get; }

        protected virtual void RegisterOtherUnitName(IList<string> collection)
        {
            // no additional unit name added
        }

        internal IReadOnlyList<string> GetUnitNames()
        {
            var collection = new List<string> {UnitName};
            RegisterOtherUnitName(collection);
            return collection;
        }

        public override string ToString()
        {
            return UnitName;
        }

        public bool Equals(Unit other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return UnitId.Equals(other.UnitId) && Equals(Category, other.Category);
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

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((Unit) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (UnitId.GetHashCode() * 397) ^ (Category != null ? Category.GetHashCode() : 0);
            }
        }
    }
}
#pragma warning restore S4035
using System;
using System.Diagnostics;

namespace Absa.Hire.Newbies.PowerConverter
{
    public abstract class Category : IEquatable<Category>
    {
        protected Category(Guid categoryId, string visibleName)
        {
            _categoryId = categoryId;
            VisibleName = visibleName;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly Guid _categoryId;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string VisibleName { get; }

        public override string ToString()
        {
            return VisibleName;
        }

        public bool Equals(Category other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return _categoryId.Equals(other._categoryId);
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

            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            return _categoryId.GetHashCode();
        }
    }
}

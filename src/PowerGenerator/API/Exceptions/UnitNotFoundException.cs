using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Absa.Hire.Newbies.PowerConverter
{
    [Serializable]
    public sealed class UnitNotFoundException : Exception
    {
        private const string ErrorMessage = "Cannot find unit \"{0}\".";

        internal UnitNotFoundException(string unitName) : base(string.Format(ErrorMessage, unitName))
        {
            UnitName = unitName;
        }

        private const string UnitNameKey = "UnitNameKey";

        public string UnitName { get; private set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private UnitNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            UnitName = info.GetString(UnitNameKey);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(UnitNameKey, UnitName);
            base.GetObjectData(info, context);
        }
    }
}
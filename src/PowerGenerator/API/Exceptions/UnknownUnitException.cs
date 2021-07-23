using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Absa.Hire.Newbies.PowerConverter.API
{
    [Serializable]
    public sealed class UnknownUnitException : Exception
    {
        private const string ErrorMessage = "Unknown unit \"{0}\".";

        internal UnknownUnitException(string unitName) : base(string.Format(ErrorMessage, unitName))
        {
            UnitName = unitName;
        }

        private const string UnitNameKey = "UnitNameKey";

        public string UnitName { get; private set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private UnknownUnitException(SerializationInfo info, StreamingContext context) : base(info, context)
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
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Absa.Hire.Newbies.PowerConverter
{
    [Serializable]
    public sealed class MappingNotFoundException : Exception
    {
        private const string ErrorMessage = "Cannot find mapping from \"{0}\" to \"{1}\".";

        internal MappingNotFoundException(string sourceUnitName, string destinationUnitName) : base(string.Format(ErrorMessage, sourceUnitName, destinationUnitName))
        {
            SourceUnitName = sourceUnitName;
            DestinationUnitName = destinationUnitName;
        }

        private const string SourceUnitNameKey = "SourceUnitNameKey";
        private const string DestinationUnitNameKey = "DestinationUnitNameKey";

        public string SourceUnitName { get; private set; }

        public string DestinationUnitName { get; private set; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        private MappingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            SourceUnitName = info.GetString(SourceUnitNameKey);
            DestinationUnitName = info.GetString(DestinationUnitNameKey);
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(SourceUnitNameKey, SourceUnitName);
            info.AddValue(DestinationUnitNameKey, DestinationUnitName);
            base.GetObjectData(info, context);
        }
    }
}
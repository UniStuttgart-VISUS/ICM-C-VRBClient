using System;

namespace covise.attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class SharedClassAttribute : Attribute
    {
        public const string defaultInstanceIDName = "instanceID";
        public string instanceIDName { get; private set; } = null;
        public InstanceIDType idType { get; private set; } = InstanceIDType.DEFAULT;
        
        public SharedClassAttribute()
        {
            this.idType = InstanceIDType.DEFAULT;
            this.instanceIDName = defaultInstanceIDName;
        }
        
        public SharedClassAttribute(string instanceIDName)
        {
            this.idType = InstanceIDType.DEFAULT;
            this.instanceIDName = instanceIDName;
        }
        
        public SharedClassAttribute(InstanceIDType idType)
        {
            this.idType = idType;
            this.instanceIDName = defaultInstanceIDName;
        }
        
        public SharedClassAttribute(InstanceIDType idType, string instanceIDName)
        {
            this.idType = idType;
            this.instanceIDName = instanceIDName;
        }
    }

    public enum InstanceIDType
    {
        DEFAULT = 0,
        AUTO = 0,
        MANUAL = 1
    }
}
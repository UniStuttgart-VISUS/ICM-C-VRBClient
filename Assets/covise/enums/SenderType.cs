using UnityEngine.UIElements.Experimental;

namespace covise.enums
{
    public class SenderType
    {
        public static readonly SenderType UNDEFINED = new SenderType(0, "UNDEFINED");
        public static readonly SenderType CONTROLLER = new SenderType(1, "CONTROLLER");
        public static readonly SenderType CRB = new SenderType(2, "CRB");
        public static readonly SenderType USERINTERFACE = new SenderType(3, "USERINTERFACE");
        public static readonly SenderType RENDERER = new SenderType(4, "RENDERER");
        public static readonly SenderType APPLICATIONMODULE = new SenderType(5, "APPLICATIONMODULE");
        public static readonly SenderType TRANSFERMANAGER = new SenderType(6, "TRANSFERMANAGER");
        public static readonly SenderType SIMPLEPROCESS = new SenderType(7, "SIMPLEPROCESS");
        public static readonly SenderType SIMPLECONTROLLER = new SenderType(8, "SIMPLECONTROLLER");
        public static readonly SenderType STDINOUT = new SenderType(9, "STDINOUT");
        public static readonly SenderType COVISED = new SenderType(10, "COVISED");
        public static readonly SenderType VRB = new SenderType(11, "VRB");
        public static readonly SenderType SENDER_SOUND = new SenderType(12, "SENDER_SOUND");
        public static readonly SenderType ANY = new SenderType(13, "ANY");

        public static readonly SenderType[] values = new SenderType[]
        {
            UNDEFINED,
            CONTROLLER,
            CRB,
            USERINTERFACE,
            RENDERER,
            APPLICATIONMODULE,
            TRANSFERMANAGER,
            SIMPLEPROCESS,
            SIMPLECONTROLLER,
            STDINOUT,
            COVISED,
            VRB,
            SENDER_SOUND,
            ANY
        };
        
        public readonly int value;
        public readonly string name;
        
        private SenderType(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        
        public static SenderType fromID(int idx)
        {
            return values[idx];
        }

        public override string ToString()
        {
            return name + " (" + value + ")";
        }
    }
}
namespace covise.enums
{
    public class ProgramType
    {
        public static readonly ProgramType COVISE = new ProgramType(0, "covise");
        public static readonly ProgramType OPENCOVER = new ProgramType(1, "opencover");
        public static readonly ProgramType COVISE_DAEMON = new ProgramType(2, "coviseDaemon");
        public static readonly ProgramType CRB = new ProgramType(3, "crb");
        public static readonly ProgramType EXTERNAL = new ProgramType(4, "external");
        public static readonly ProgramType LAST_DUMMY = new ProgramType(5, "LAST_DUMMY");
        
        public static readonly ProgramType[] values = new ProgramType[]
        {
            COVISE,
            OPENCOVER,
            COVISE_DAEMON,
            CRB,
            EXTERNAL,
            LAST_DUMMY,
        };
        
        public readonly int id;
        public readonly string name;
        
        private ProgramType(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        
        public static ProgramType fromID(byte id)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].id == id)
                {
                    return values[i];
                }
            }

            return COVISE;
        }

        public static string[] listNames()
        {
            string[] names = new string[values.Length];
            
            for (int i = 0; i < values.Length; i++)
            {
                names[i] = values[i].name;
            }

            return names;
        }
        
        
        public override string ToString()
        {
            return name + " (" + id + ")";
        }
        
    }
}
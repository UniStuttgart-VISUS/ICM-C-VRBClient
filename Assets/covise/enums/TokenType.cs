using System;

namespace covise.enums
{
    public class TokenType
    {

        public static readonly TokenType BOOL = new TokenType(0x07, typeof(bool), "BOOL");
        public static readonly TokenType INT64 = new TokenType(0x08, typeof(long), "LONG");
        public static readonly TokenType INT32 = new TokenType(0x09, typeof(int), "INT");
        public static readonly TokenType FLOAT = new TokenType(0x0a, typeof(float), "FLOAT");
        public static readonly TokenType DOUBLE = new TokenType(0x0b, typeof(double), "DOUBLE");
        public static readonly TokenType STRING = new TokenType(0x0c, typeof(string), "STRING");
        public static readonly TokenType CHAR = new TokenType(0x0d, typeof(char), "CHAR");
        public static readonly TokenType DATA = new TokenType(0x0e, null, "DATA"); // TokenBuffer or DataHandle
        public static readonly TokenType BINARY = new TokenType(0x0f, null, "BINARY");
        
        public static readonly TokenType NOTOKEN = new TokenType(0xff, null, "NOTOKEN");
        
        // Aliases
        public static readonly TokenType BYTE = CHAR;
        public static readonly TokenType LONG = INT64;
        public static readonly TokenType INT = INT32;
        public static readonly TokenType TB = DATA;
        
        public static readonly TokenType[] values = new TokenType[]
        {
            BOOL,
            INT64,
            INT32,
            FLOAT,
            DOUBLE,
            STRING,
            CHAR,
            DATA,
            BINARY,
            NOTOKEN
        };
        
        public readonly byte id;
        public readonly Type type;
        public readonly string name;
        
        private TokenType(byte id, Type type, string name)
        {
            this.id = id;
            this.type = type;
            this.name = name;
        }

        public static TokenType fromID(byte id)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].id == id)
                {
                    return values[i];
                }
            }

            return NOTOKEN;
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
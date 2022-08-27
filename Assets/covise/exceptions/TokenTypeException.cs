using System;
using System.Reflection;
using covise.enums;

namespace covise.exceptions
{
    public class TokenTypeException: Exception
    {
        public TokenTypeException(TokenType expected, byte type) : 
            base("Got wrong TokenType. Expected " + expected.name + ", got " + TokenType.fromID(type).name)
        {
            // Not Implemented
        }
        
        public TokenTypeException(TokenType expected, byte type, Exception inner) : 
            base("Got wrong TokenType. Expected " + expected.name + ", got " + TokenType.fromID(type).name, inner)
        {
            // Not Implemented
        }
    }
}
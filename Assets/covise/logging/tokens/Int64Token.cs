using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class Int64Token: AbstractToken<long>
    {
        public Int64Token(long value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.INT64;
        }

        public override int getTokenSize()
        {
            return 8;
        }
    }
    
}
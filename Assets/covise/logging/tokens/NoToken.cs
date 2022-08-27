using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class NoToken: AbstractToken<byte>
    {
        public NoToken(byte value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.NOTOKEN;
        }

        public override int getTokenSize()
        {
            return 1;
        }
    }
}
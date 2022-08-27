using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class CharToken: AbstractToken<byte>
    {
        public CharToken(byte value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        public override TokenType getTokenType()
        {
            return TokenType.CHAR;
        }

        public override int getTokenSize()
        {
            return 1;
        }
    }
}
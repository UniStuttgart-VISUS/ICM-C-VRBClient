using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class BinaryToken: AbstractToken<byte[]>
    {
        public BinaryToken(byte[] value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }

        public override TokenType getTokenType()
        {
            return TokenType.BINARY;
        }

        public override int getTokenSize()
        {
            return getValue().Length;
        }
    }
}
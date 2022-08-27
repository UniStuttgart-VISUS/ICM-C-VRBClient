using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class DataToken: AbstractToken<byte[]>
    {
        public DataToken(byte[] value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.DATA;
        }

        public override int getTokenSize()
        {
            return getValue().Length;
        }
    }
}
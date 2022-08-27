using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class Int32Token: AbstractToken<int>
    {
        public Int32Token(int value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        public override TokenType getTokenType()
        {
            return TokenType.INT32;
        }

        public override int getTokenSize()
        {
            return 4;
        }
    }
    
}
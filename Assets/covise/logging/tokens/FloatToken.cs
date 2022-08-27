using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class FloatToken: AbstractToken<float>
    {
        public FloatToken(float value, IToken prev): base(value, prev)
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
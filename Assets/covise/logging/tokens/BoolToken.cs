using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class BoolToken: AbstractToken<bool>
    {
        public BoolToken(bool value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.BOOL;
        }

        public override int getTokenSize()
        {
            return 1;
        }
    }
}
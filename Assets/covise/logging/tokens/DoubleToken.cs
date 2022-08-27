using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class DoubleToken: AbstractToken<double>
    {
        public DoubleToken(double value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.DOUBLE;
        }

        public override int getTokenSize()
        {
            return 8;
        }
    }
    
}
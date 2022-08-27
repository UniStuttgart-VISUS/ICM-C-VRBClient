using System.Text;
using covise.logging.tokens;
using covise.enums;

namespace covise.logging.tokens
{
    public class StringToken: AbstractToken<string>
    {
        public StringToken(string value, IToken prev): base(value, prev)
        {
            // Not Implemented
        }
        
        public override TokenType getTokenType()
        {
            return TokenType.STRING;
        }

        public override int getTokenSize()
        {
            return getValue().Length;
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(getTokenType());
            sb.Append("\t Length: ");
            sb.Append(getTokenSize());
            sb.Append("\t Value: '");
            sb.Append(getValue());
            sb.Append("'");
            
            return sb.ToString();
        }
    }
    
}
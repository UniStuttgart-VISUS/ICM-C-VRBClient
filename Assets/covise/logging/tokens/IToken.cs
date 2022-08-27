using covise.enums;

namespace covise.logging.tokens
{
    public interface IToken
    {
        public TokenType getTokenType();
        
        public int getTokenSize();

        public IToken getNext();
        public IToken getPrev();

        public void setNext(IToken token);
        public void setPrev(IToken token);
    }
}
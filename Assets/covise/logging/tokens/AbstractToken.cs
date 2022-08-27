using System.Text;
using covise.enums;

namespace covise.logging.tokens
{
    public abstract class AbstractToken<T>: IToken
    {
        private T value;

        private IToken next;
        private IToken prev;

        public AbstractToken(T value, IToken prev = null)
        {
            this.value = value;

            this.next = null;
            this.prev = prev;

            if (this.prev != null)
            {
                this.prev.setNext(this);
            }
        }

        public IToken getNext()
        {
            return next;
        }

        public IToken getPrev()
        {
            return prev;
        }

        public void setNext(IToken token)
        {
            this.next = token;
            if (token.getPrev() != this)
            {
                token.setPrev(this);
            }
        }

        public void setPrev(IToken token)
        {
            this.prev = token;
            if (token.getNext() != this)
            {
                token.setNext(this);
            }
        }

        public abstract TokenType getTokenType();

        public T getValue()
        {
            return value;
        }

        public void setValue(T value)
        {
            this.value = value;
        }

        public abstract int getTokenSize();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.Append(getTokenType());
            sb.Append("\t Length: ");
            sb.Append(getTokenSize());
            sb.Append("\t Value: ");
            sb.Append(getValue());
            
            return sb.ToString();
        }
    }
}
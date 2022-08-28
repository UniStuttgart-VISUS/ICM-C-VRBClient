using covise.serialisation;

namespace covise.sharedstate
{
    public interface IShareable
    {
        public TokenBuffer serialize(TokenBuffer buffer);

        public void deserialize(TokenBuffer buffer, ref int position);
        
        public void deserialize(TokenBuffer buffer, int position);
    }
}
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using covise.glue;
using covise.logging.tokens;
using covise.enums;
using Debug = UnityEngine.Debug;

namespace covise.logging
{
    public class TokenList
    {
        private IToken root;
        private IToken last;

        public TokenList()
        {
        }

        public void fromBytes(byte[] data)
        {
            int pos = 0;
            
            while (pos < data.Length)
            {
                TokenType type = TokenType.fromID(data[pos]);
                if (type == TokenType.BOOL)
                {
                    pos += 1;
                    last = new BoolToken(ByteTools.getBool(ref data, pos), last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.INT64)
                {
                    pos += 1;
                    last = new Int64Token(ByteTools.getLong(ref data, pos), last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.INT32)
                {
                    pos += 1;
                    last = new Int32Token(ByteTools.getInt(ref data, pos), last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.FLOAT)
                {
                    pos += 1;
                    last = new FloatToken(ByteTools.getFloat(ref data, pos), last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.DOUBLE)
                {
                    pos += 1;
                    last = new DoubleToken(ByteTools.getDouble(ref data, pos), last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.STRING)
                {
                    pos += 1;
                    last = new StringToken(ByteTools.getString(ref data, pos), last);
                    pos += last.getTokenSize() +1;
                } else if (type == TokenType.CHAR)
                {
                    pos += 1;
                    last = new CharToken(data[pos], last);
                    pos += last.getTokenSize();
                } else if (type == TokenType.DATA)
                {
                    Debug.LogError("DATA Token Detected. No Deserialisation for Data Token available. Please implement Deserialiser.");
                } else if (type == TokenType.BINARY)
                {
                    Debug.LogError("BINARY Token Detected. No Deserialisation for BINARY Token available. Please implement Deserialiser.");
                } else // NOTOKEN
                {
                    last = new NoToken(data[pos], last);
                    pos += 1;
                }

                if (root == null)
                {
                    root = last;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            IToken token = root;
            int count = 0;

            while (token != null)
            {
                sb.Append("[");
                sb.Append(count++);
                sb.Append("] ");
                sb.Append(token);
                sb.Append('\n');

                token = token.getNext();
            }

            return sb.ToString();
        }
    }
}
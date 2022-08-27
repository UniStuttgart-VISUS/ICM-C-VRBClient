using System.Collections.Generic;
using covise.glue;
using covise.enums;
using covise.exceptions;
using covise.structs;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.tvOS;
using UnityEngine.UIElements;

namespace covise.serialisation
{
    public class TokenBuffer
    {
        private List<byte> bytes;

        private bool isDebugFormat = false;
        
        public TokenBuffer(bool isDebugFormat=false)
        {
            bytes = new List<byte>();
            this.isDebugFormat = isDebugFormat;
            putRaw((byte)(this.isDebugFormat?0x01:0x00));
        }

        public TokenBuffer(byte[] data)
        {
            bytes = new List<byte>();
            bytes.AddRange(data);
            this.isDebugFormat = (bytes[0] == 0x01);
        }

        public bool isDebug()
        {
            return isDebugFormat;
        }

        #region Serialisation

        #region Primitives
        
        public void putRaw(byte data)
        {
            bytes.Add(data);
        }

        public void putRaw(byte[] data)
        {
            bytes.AddRange(data);
        }

        public void putType(TokenType type)
        {
            if (isDebugFormat)
            {
                bytes.Add(type.id);
            }
        }

        public void append(bool value)
        {
            putType(TokenType.BOOL);
            ByteTools.putValue(ref bytes, value, -1);
        }

        public void append(char value)
        {
            putType(TokenType.CHAR);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(short value)
        {
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(int value)
        {
            putType(TokenType.INT);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(long value)
        {
            putType(TokenType.LONG);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(ushort value)
        {
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(uint value)
        {
            putType(TokenType.INT);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(ulong value)
        {
            putType(TokenType.LONG);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(float value)
        {
            putType(TokenType.FLOAT);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(double value)
        {
            putType(TokenType.DOUBLE);
            ByteTools.putValue(ref bytes, value, -1);
        }
        
        public void append(string value)
        {
            putType(TokenType.STRING);
            ByteTools.putValue(ref bytes, value, -1);
        }

        /*public void append(byte[] value)
        {
            putType(TokenType.BINARY);
            //append(value.Length); 
            ByteTools.putData(ref bytes, value, -1);
        }*/

        public void append(TokenBuffer value)
        {
            putType(TokenType.TB);
            byte[] valbytes = value.ToBytes();
            append(valbytes.Length); 
            putType(TokenType.BINARY);
            ByteTools.putData(ref bytes, valbytes, -1);
        }
        
        #endregion

        #region Structs

        public void append(SessionID value)
        {
            append(value.name);
            append(value.owner);
            append(value.isPrivate);
            append(value.master);
        }

        public void append(UserInfo value)
        {
            append(value.userType);
            append(value.userName);
            append(value.ipAddress);
            append(value.hostname);
            append(value.emailAddress);
            append(value.url);
        }

        public void append(RemoteClient value)
        {
            append(value.id);
            append(value.publicID);
            append(value.privateID);
        }

        #endregion
        
        public byte[] ToBytes()
        {
            return bytes.ToArray();
        }
        
        #endregion

        #region Deserialisation

        #region Primitives
        
        public void checkType(ref int position, TokenType expected)
        {
            byte type = bytes[position++];
            if (isDebugFormat && type != expected.id)
            {
                throw new TokenTypeException(expected, type);
            }
        }

        public byte getByte(ref int position)
        {
            checkType(ref position, TokenType.BYTE);
            return bytes[position++];
        }

        public byte getByte(int position)
        {
            checkType(ref position, TokenType.BYTE);
            return bytes[position++];
        }

        public bool getBool(ref int position)
        {
            checkType(ref position, TokenType.BOOL);
            bool ret = ByteTools.getBool(ref bytes, position);
            position += 1;
            return ret;
        }
        
        public bool getBool(int position)
        {
            checkType(ref position, TokenType.BOOL);
            bool ret = ByteTools.getBool(ref bytes, position);
            return ret;
        }

        public char getChar(ref int position)
        {
            checkType(ref position, TokenType.CHAR);
            char ret = ByteTools.getChar(ref bytes, position);
            position += 1;
            return ret;
        }
        
        public char getChar(int position)
        {
            checkType(ref position, TokenType.CHAR);
            char ret = ByteTools.getChar(ref bytes, position);
            return ret;
        }

        public int getInt(ref int position)
        {
            checkType(ref position, TokenType.INT32);
            int ret = ByteTools.getInt(ref bytes, position);
            position += 4;
            return ret;
        }

        public int getInt(int position)
        {
            checkType(ref position, TokenType.INT32);
            int ret = ByteTools.getInt(ref bytes, position);
            return ret;
        }

        public long getLong(ref int position)
        {
            checkType(ref position, TokenType.INT64);
            long ret = ByteTools.getLong(ref bytes, position);
            position += 8;
            return ret;
        }
        
        public long getLong(int position)
        {
            checkType(ref position, TokenType.INT64);
            long ret = ByteTools.getLong(ref bytes, position);
            return ret;
        }
        
        public uint getUInt(ref int position)
        {
            checkType(ref position, TokenType.INT);
            uint ret = ByteTools.getUInt(ref bytes, position);
            position += 4;
            return ret;
        }

        public uint getUInt(int position)
        {
            checkType(ref position, TokenType.INT32);
            uint ret = ByteTools.getUInt(ref bytes, position);
            return ret;
        }

        public ulong getULong(ref int position)
        {
            checkType(ref position, TokenType.INT64);
            ulong ret = ByteTools.getULong(ref bytes, position);
            position += 8;
            return ret;
        }
        
        public ulong getULong(int position)
        {
            checkType(ref position, TokenType.INT64);
            ulong ret = ByteTools.getULong(ref bytes, position);
            return ret;
        }

        public float getFloat(ref int position)
        {
            checkType(ref position, TokenType.FLOAT);
            float ret = ByteTools.getFloat(ref bytes, position);
            position += 4;
            return ret;
        }
        
        public float getFloat(int position)
        {
            checkType(ref position, TokenType.FLOAT);
            float ret = ByteTools.getFloat(ref bytes, position);
            return ret;
        }
        
        public double getDouble(ref int position)
        {
            checkType(ref position, TokenType.DOUBLE);
            double ret = ByteTools.getDouble(ref bytes, position);
            position += 8;
            return ret;
        }
        
        public double getDouble(int position)
        {
            checkType(ref position, TokenType.DOUBLE);
            double ret = ByteTools.getDouble(ref bytes, position);
            return ret;
        }
        
        public string getString(ref int position)
        {
            checkType(ref position, TokenType.STRING);
            int byteCount;
            string ret = ByteTools.getString(ref bytes, out byteCount, position);
            position += byteCount;
            return ret;
        }
        
        public string getString(int position)
        {
            checkType(ref position, TokenType.DOUBLE);
            return ByteTools.getString(ref bytes, position);
        }
        
        public TokenBuffer getTokenBuffer(ref int position)
        {
            checkType(ref position, TokenType.TB);
            int length = getInt(ref position);
            checkType(ref position, TokenType.BINARY);
            byte[] data = ByteTools.getData(ref bytes, length, position);
            position += length;

            return new TokenBuffer(data);
        }
        
        public TokenBuffer getTokenBuffer(int position)
        {
            checkType(ref position, TokenType.TB);
            int length = getInt(ref position);
            checkType(ref position, TokenType.BINARY);
            byte[] data = ByteTools.getData(ref bytes, length, position);

            return new TokenBuffer(data);
        }
        
        #endregion

        #region Structs

        public SessionID getSessionID(ref int position)
        {
            SessionID ret = new SessionID();
            ret.name = getString(ref position);
            ret.owner = getInt(ref position);
            ret.isPrivate = getBool(ref position);
            ret.master = getInt(ref position);
            return ret;
        }
        
        public SessionID getSessionID(int position)
        {
            SessionID ret = new SessionID();
            ret.name = getString(ref position);
            ret.owner = getInt(ref position);
            ret.isPrivate = getBool(ref position);
            ret.master = getInt(ref position);

            return ret;
        }

        public UserInfo getUserInfo(ref int position)
        {
            UserInfo ret = new UserInfo();
            ret.userType = getInt(ref position);
            ret.userName = getString(ref position);
            ret.ipAddress = getString(ref position);
            ret.hostname = getString(ref position);
            ret.emailAddress = getString(ref position);
            ret.url = getString(ref position);

            return ret;
        }

        public UserInfo getUserInfo(int position)
        {
            UserInfo ret = new UserInfo();
            ret.userType = getInt(ref position);
            ret.userName = getString(ref position);
            ret.ipAddress = getString(ref position);
            ret.hostname = getString(ref position);
            ret.emailAddress = getString(ref position);
            ret.url = getString(ref position);

            return ret;
        }
        
        public RemoteClient getRemoteClient(ref int position)
        {
            RemoteClient ret = new RemoteClient();
            ret.id = getInt(ref position);
            ret.publicID = getSessionID(ref position);
            ret.privateID = getSessionID(ref position);

            return ret;
        }
        
        public RemoteClient getRemoteClient(int position)
        {
            RemoteClient ret = new RemoteClient();
            ret.id = getInt(ref position);
            ret.publicID = getSessionID(ref position);
            ret.privateID = getSessionID(ref position);

            return ret;
        }
        
        #endregion

        #endregion

    }
}
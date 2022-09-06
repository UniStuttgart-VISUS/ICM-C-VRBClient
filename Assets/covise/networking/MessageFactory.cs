using covise.enums;
using covise.serialisation;
using covise.structs;

namespace covise.networking
{
    public class MessageFactory
    {
        public static bool USE_TOKENBUFFER_DEBUG_FORMAT = true;

        #region VRB Bookkeeping

        public static Message createVRB_CONTACT(int sender, SenderType senderType, SessionID sessionID, UserInfo userInfo)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            buffer.append((int)0);
            buffer.append(sessionID);
            buffer.append(userInfo);
            
            return new Message(sender, senderType, MessageType.VRB_CONTACT, buffer.ToBytes());
        }

        public static Message createVRB_REQUEST_NEW_SESSION(int sender, SenderType senderType, SessionID publicSession)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            buffer.append(publicSession);
            return new Message(sender, senderType, MessageType.VRB_REQUEST_NEW_SESSION, buffer.ToBytes());
        }

        public static Message createVRBC_SET_SESSION(int sender, SenderType senderType, int senderID, SessionID publicSession)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            buffer.append(senderID);
            buffer.append(publicSession);
            return new Message(sender, senderType, MessageType.VRBC_SET_SESSION, buffer.ToBytes());
        }
        
        #endregion

        #region VRB Registry

        public static Message createVRB_REGISTRY_SUBSCRIBE_CLASS(int sender, SenderType senderType, SessionID publicSession, int classID, string name)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(classID);
            buffer.append(name);

            return new Message(sender, senderType, MessageType.VRB_REGISTRY_SUBSCRIBE_CLASS, buffer.ToBytes());
        }

        public static Message createVRB_REGISTRY_SUBSCRIBE_VARIABLE(int sender, SenderType senderType, 
            SessionID publicSession, int classID, string className, string varName)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(classID);
            buffer.append(className);
            buffer.append(varName);

            return new Message(sender, senderType, MessageType.VRB_REGISTRY_SUBSCRIBE_VARIABLE, buffer.ToBytes());
        }
        public static Message createVRB_REGISTRY_CREATE_ENTRY(int sender, SenderType senderType, SessionID publicSession,
            int clientID, string cl, string var, TokenBuffer value, bool isStatic)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(clientID);
            buffer.append(cl);
            buffer.append(var);
            buffer.append(value);
            buffer.append(isStatic);
            
            return new Message(sender, senderType, MessageType.VRB_REGISTRY_CREATE_ENTRY, buffer.ToBytes());
        }

        public static Message createVRB_REGISTRY_SET_VALUE(int sender, SenderType senderType, SessionID publicSession,
            int clientID, string cl, string var, TokenBuffer value)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(clientID);
            buffer.append(cl);
            buffer.append(var);
            buffer.append(value);
            
            return new Message(sender, senderType, MessageType.VRB_REGISTRY_SET_VALUE, buffer.ToBytes());
        }
        
        public static Message createVRB_REGISTRY_DELETE_ENTRY(int sender, SenderType senderType, SessionID publicSession,
            int clientID, string cl, string var)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(clientID);
            buffer.append(cl);
            buffer.append(var);
            
            return new Message(sender, senderType, MessageType.VRB_REGISTRY_DELETE_ENTRY, buffer.ToBytes());
        }
        
        public static Message createVRB_REGISTRY_UNSUBSCRIBE_CLASS(int sender, SenderType senderType, SessionID publicSession, int classID, string name)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(classID);
            buffer.append(name);

            return new Message(sender, senderType, MessageType.VRB_REGISTRY_UNSUBSCRIBE_CLASS, buffer.ToBytes());
        }

        public static Message createVRB_REGISTRY_UNSUBSCRIBE_VARIABLE(int sender, SenderType senderType, 
            SessionID publicSession, int classID, string className, string varName)
        {
            TokenBuffer buffer = new TokenBuffer(USE_TOKENBUFFER_DEBUG_FORMAT);
            
            buffer.append(publicSession);
            buffer.append(classID);
            buffer.append(className);
            buffer.append(varName);

            return new Message(sender, senderType, MessageType.VRB_REGISTRY_UNSUBSCRIBE_VARIABLE, buffer.ToBytes());
        }
        
        #endregion
        
    }
}
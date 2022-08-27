using System.Collections;
using System.Collections.Generic;
using System.Text;
using covise.glue;
using covise.logging;
using covise.enums;
using covise.serialisation;
using UnityEngine;

namespace covise.networking
{
    public class Message
    {
        public const int HEADER_SIZE = 16;
        
        private int __sender;
        public int sender {
            get
            {
                return __sender;
            }
            set
            {
                __sender = value & 0x00ffffff; // Ensure sender has max. 3 bytes, as (probably) specified in protocol. See message.h for reason
            }
        }
    
        public SenderType senderType;
        public MessageType messageType;
    
        public byte[] payload;
    
        /// <summary>
        /// Creates an empty message
        /// </summary>
        /// <param name="sender">Sender ID to use</param>
        public Message(int sender) : this(sender, SenderType.UNDEFINED, MessageType.EMPTY)
        {
            // Not Implemented
        }
        
        /// <summary>
        /// Creates a new Message
        /// </summary>
        /// <param name="sender">SenderID to use</param>
        /// <param name="messageType">Type of the message</param>
        public Message(int sender, MessageType messageType) : this(sender, SenderType.UNDEFINED, messageType)
        {
            // Not Implemented
        }
        
        /// <summary>
        /// Creates a new Message
        /// </summary>
        /// <param name="sender">SenderID to use</param>
        /// <param name="senderType">Type of the sender</param>
        public Message(int sender, SenderType senderType) : this(sender, senderType, MessageType.EMPTY)
        {
            // Not Implemented
        }
    
        /// <summary>
        /// Creates a new Message
        /// </summary>
        /// <param name="sender">SenderID to use</param>
        /// <param name="senderType">Type of the sender</param>
        /// <param name="messageType">Type of the message</param>
        public Message(int sender, SenderType senderType, MessageType messageType) : this(sender, senderType, messageType, null)
        {
            // Not Implemented
        }
        
        /// <summary>
        /// Creates a new Message
        /// </summary>
        /// <param name="sender">SenderID to use</param>
        /// <param name="senderType">Type of the sender</param>
        /// <param name="messageType">Type of the message</param>
        /// <param name="payload">Payload of the message</param>
        public Message(int sender, SenderType senderType, MessageType messageType, byte[] payload)
        {
            this.sender = sender;
            this.senderType = senderType;
            this.messageType = messageType;
            this.payload = payload;
        }
        
        /// <summary>
        /// Sets the Payload of this message
        /// </summary>
        /// <param name="payload">New Payload for this message</param>
        public void setPayload(byte[] payload)
        {
            this.payload = payload;
        }

        public TokenBuffer getTokenBuffer()
        {
            return new TokenBuffer(payload);
        }

        /// <summary>
        /// Checks if the message is complete or Header-Only. Incomplete messages have a payload of null
        /// </summary>
        /// <returns>True if the message is complete including payload, false otherwise</returns>
        public bool isComplete()
        {
            return payload != null;
        }

        /// <summary>
        /// Assembles the message to a byte[], ready to send
        /// </summary>
        /// <returns>the assembled message</returns>
        public byte[] assembleMessage()
        {
            byte[] message = new byte[payload.Length + HEADER_SIZE];
    
            ByteTools.putValue(ref message, sender, 0, true);
            ByteTools.putValue(ref message, senderType.value, 4, true);
            ByteTools.putValue(ref message, messageType.value, 8, true);
            ByteTools.putValue(ref message, payload.Length, 12, true);
            
            ByteTools.putData(ref message, payload, 16, false);
            
            return message;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nMessage Sender: ");
            sb.Append(this.sender);
            sb.Append("\nMessage Sender Type: ");
            sb.Append(senderType);
            sb.Append("\nMessage Type: ");
            sb.Append(messageType);
            sb.Append("\nPayload Length:");

            if (payload != null)
            {
                sb.Append(payload.Length);
                sb.Append("\nTokenList:\n");

                TokenList list = new TokenList();
                list.fromBytes(payload);
                sb.Append(list);
            }
            else
            {
                sb.Append(-1);
                sb.Append('\n');
            }

            sb.Append("END");
           
            return sb.ToString();
        }

        public static Message fromBytes(byte[] rawMessage)
        {
            int sender = ByteTools.getInt(ref rawMessage, 0, true);
            int senderType = ByteTools.getInt(ref rawMessage, 4, true);
            int messageType = ByteTools.getInt(ref rawMessage, 8, true);
            int payload_len = ByteTools.getInt(ref rawMessage, 12, true);

            byte[] payload = ByteTools.getData(ref rawMessage, payload_len, 16, false);

            return new Message(sender, SenderType.fromID(senderType), MessageType.fromID(messageType), payload);
        }

        public static Message fromHeaderBytes(byte[] header, out int payloadLength)
        {
            int sender = ByteTools.getInt(ref header, 0, true);
            int senderType = ByteTools.getInt(ref header, 4, true);
            int messageType = ByteTools.getInt(ref header, 8, true);
            payloadLength = ByteTools.getInt(ref header, 12, true);
            
            return new Message(sender, SenderType.fromID(senderType), MessageType.fromID(messageType));
        }
    }
}


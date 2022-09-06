using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using covise.enums;
using covise.managers;
using covise.serialisation;
using covise.structs;
using UnityEngine;
using MessageType = covise.enums.MessageType;

namespace covise.networking
{
    public class VRBClient
    {
        private TcpClient client;

        private string host;
        private int port;
        
        private volatile bool running;
        private bool autopoll = true;
        
        public EventHandler onMessageReceived;
        public EventHandler onMessage;
        
        private SessionManager sessionManager;

        private UserInfo userInfo;
        //private SessionID sessionID;
        
        private RemoteClient remoteClient;
        public Task pollTask;

        public VRBClient(IPEndPoint endPoint)
        {
            this.host = endPoint.Address.ToString();
            this.port = endPoint.Port;
            this.client = new TcpClient();
            
            this.userInfo = new UserInfo();
            this.remoteClient = new RemoteClient();
            this.sessionManager = new SessionManager();
        }

        public VRBClient(string host, int port)
        {
            this.host = host;
            this.port = port;
            this.client = new TcpClient();
            
            this.userInfo = new UserInfo();
            this.remoteClient = new RemoteClient();
            this.sessionManager = new SessionManager();
        }

        public SessionID getPublicSession()
        {
            return remoteClient.publicID;
        }

        public int getClientID()
        {
            return remoteClient.id;
        }

        #region Setup

        public void setAddress(IPEndPoint endPoint)
        {
            checkNotConnected("setAddress");
            this.host = endPoint.Address.ToString();
            this.port = endPoint.Port;
        }

        public void setAddress(string host, int port)
        {
            checkNotConnected("setAddress");
            this.host = host;
            this.port = port;
        }

        public void setUserInformation(string username, string mail, string url)
        {
            checkNotConnected("setUserInformation");
            string host = Dns.GetHostName();

            this.userInfo.userName = username;
            this.userInfo.emailAddress = mail;
            this.userInfo.url = url;

            this.userInfo.hostname = host;
            this.userInfo.ipAddress = tryGetIp4(host);
        }

        private string tryGetIp4(string host)
        {
            foreach (IPAddress address in Dns.GetHostAddresses(host))
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }

            return Dns.GetHostAddresses(host)[0].ToString();
        }

        public void setupDefaultHandlers()
        {
            this.onMessageReceived += delegate(object sender, EventArgs args)
            {
                handleMessageLowLevel(((MessageEventArgs) args).message);
            };
        }

        public void connect()
        {
            checkNotConnected("connect");
            this.client.Connect(this.host, this.port);

            this.running = true;
            
            this.client.GetStream().Write(new byte[]{0x01}, 0, 1);
            this.client.GetStream().Flush();

            // Create empty SessionID, since it is required, but not set
            SessionID sessionID = new SessionID();
            sessionID.name = "";
            sessionID.isPrivate = true;
            
            sendMessage(MessageFactory.createVRB_CONTACT(0, SenderType.fromID(0), sessionID, userInfo));

            if (autopoll)
            {
                pollTask = Task.Run(() => receiveMessagesAsync());
            }
        }

        public void disconnect()
        {
            checkConnected("disconnect");
            this.running = false;
            this.client.Close();
        }

        #endregion
        
        #region Message Handling
        
        public async Task receiveMessagesAsync()
        {
            byte[] header = new byte[Message.HEADER_SIZE];
            Stream stream = this.client.GetStream();

            int b = stream.ReadByte();
            
            int bytesRead;
            int payloadLen;
            
            while (this.running)
            {
                bytesRead = 0;
                while (bytesRead < header.Length)
                {
                    
                    bytesRead += await stream.ReadAsync(header, bytesRead, header.Length - bytesRead);
                }
                
                Debug.Log("Message Receiving");
                
                Message message = Message.fromHeaderBytes(header, out payloadLen);
                bytesRead = 0;
                byte[] payload = new byte[payloadLen];
                while (bytesRead < payloadLen)
                {
                    bytesRead += await stream.ReadAsync(payload, bytesRead, payload.Length - bytesRead);
                }
                
                message.setPayload(payload);
                invokeMessageRCVEvent(message);
            }
        }
        
        protected void invokeMessageRCVEvent(Message message)
        {
            onMessageReceived.Invoke(this, new MessageEventArgs(message));
        }

        protected void handleMessageLowLevel(Message message)
        {
            Debug.Log(message);
            TokenBuffer buffer = message.getTokenBuffer();
            int position = 1; // 1 because of debug mode byte
            
            Debug.Log("Message Received: \n" + message);
            
            switch (message.messageType.value)
            {
                case MessageType.ID_VRB_SET_USERINFO:
                    int clientCount_userinfo = buffer.getInt(ref position);
                    int thisPos_userinfo = buffer.getInt(ref position);
                    
                    List<RemoteClient> clients = new List<RemoteClient>();
                    for (int i = 0; i < clientCount_userinfo; i++)
                    {   
                        clients.Add(buffer.getRemoteClient(ref position));
                    }

                    this.remoteClient = clients[thisPos_userinfo];
                    break;
                
                case MessageType.ID_VRBC_SET_SESSION:
                    int senderID = buffer.getInt(ref position);
                    SessionID publicSession = buffer.getSessionID(ref position);
                    if (senderID == remoteClient.id)
                    {
                        this.remoteClient.publicID = publicSession;
                    }
                    else
                    {
                        this.sessionManager.setSession(senderID, publicSession);
                    }
                    break;
                
                case MessageType.ID_VRBC_SEND_SESSIONS:
                    Debug.Log("VRBC_SEND_SESSIONS");
                    int sessionCount_sendsessions = buffer.getInt(ref position);
                    
                    for (int i = 0; i < sessionCount_sendsessions; i++)
                    {
                        this.sessionManager.setSession(i, buffer.getSessionID(ref position));
                    }
                    break;
                
                default:
                    handleMessage(message);
                    break;
            }
        }

        protected virtual void handleMessage(Message message)
        {
            onMessage.Invoke(this, new MessageEventArgs(message));
        }
        
        public void sendMessage(Message message)
        {
            checkConnected("sendMessage");
            byte[] buffer = message.assembleMessage();
            this.client.GetStream().Write(buffer, 0, buffer.Length);
            this.client.GetStream().Flush();
        }
        
        #endregion

        #region High Level

        public SessionID[] listSessions()
        {
            checkConnected("listSessions");
            return sessionManager.getSessions();
        }

        public virtual void createPublicSession(String sessionName)
        {
            SessionID publicSession = new SessionID();
            publicSession.name = sessionName;
            publicSession.isPrivate = false;
            publicSession.master = remoteClient.id;
            publicSession.owner = remoteClient.id;
            
            sendMessage(MessageFactory.createVRB_REQUEST_NEW_SESSION(remoteClient.id, SenderType.UNDEFINED, publicSession));
        }

        public virtual void joinPublicSession(int senderID, SessionID sessionID)
        {
            sendMessage(MessageFactory.createVRBC_SET_SESSION(remoteClient.id, SenderType.UNDEFINED, senderID, sessionID));
        }

        #endregion

        #region Error Handling

        public void checkConnected(string op)
        {
            if (!this.running)
            {
                throw new Exception("Can not execute operation '"+ op +"' at this moment. Client is not connected !");
            }
        }

        public void checkNotConnected(string op)
        {
            if (this.running)
            {
                throw new Exception("Can not execute operation '"+ op +"' at this moment. Client is already connected !");
            }
        }
        
        #endregion

        public int getSenderID()
        {
            return remoteClient.id;
        }
    }
}
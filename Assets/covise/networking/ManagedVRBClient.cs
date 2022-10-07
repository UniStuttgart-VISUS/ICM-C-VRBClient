using System;
using System.Net;
using covise.managers;
using covise.sharedstate;
using covise.sharedstate.connectors;
using covise.structs;

namespace covise.networking
{
    public class ManagedVRBClient: VRBClient
    {
        private SharedStateManager stateManager;
        
        public ManagedVRBClient(IPEndPoint endPoint) : base(endPoint)
        {
            this.stateManager = SharedStateManager.getInstance();
        }

        public ManagedVRBClient(string host, int port) : base(host, port)
        {
            SharedStateManager.CONNECTOR = new VRBConnector(this);
            this.stateManager = SharedStateManager.getInstance();
            
        }
        
        protected override void handleMessage(Message message)
        {
            switch (message.messageType)
            {
                
                default:
                    invokeOnMessage(message);
                    break;
            }
        }

        private void invokeOnMessage(Message message)
        {
            onMessage.Invoke(this, new MessageEventArgs(message));
        }

        #region High Level
        

        public override void createPublicSession(String sessionName)
        {
            base.createPublicSession(sessionName);
            stateManager.registerAllSharedVariables();
            stateManager.subscribeToAllSharedVariables();
        }

        public override void joinPublicSession(int senderID, SessionID sessionID)
        {
            base.joinPublicSession(senderID, sessionID);
            stateManager.subscribeToAllSharedVariables();
        }

        #endregion
    }
}
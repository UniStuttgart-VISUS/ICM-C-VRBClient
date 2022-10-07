using covise.enums;
using covise.networking;

namespace covise.sharedstate.connectors
{
    public class VRBConnector: IConnector
    {
        private VRBClient client;

        public VRBConnector(VRBClient client)
        {
            this.client = client;
        }

        public void registerVariable(SharedVariableInterface variable)
        {
            Message msg = MessageFactory.createVRB_REGISTRY_CREATE_ENTRY(client.getSenderID(), SenderType.UNDEFINED,
                client.getPublicSession(),
                client.getClientID(), variable.getClassInstance(), variable.getVariableName(), variable.getAsTokenbuffer(), false);
            
            client.sendMessage(msg);
            
            variable.setSyncronizing(true);
        }

        public void deleteVariable(SharedVariableInterface variable)
        {
 //           throw new System.NotImplementedException();
            variable.setSyncronizing(false);
        }

        public void subscribeVariable(SharedVariableInterface variable)
        {
            Message msg = MessageFactory.createVRB_REGISTRY_SUBSCRIBE_VARIABLE(client.getSenderID(),
                SenderType.UNDEFINED,
                client.getPublicSession(), client.getClientID(), variable.getClassInstance(),
                variable.getVariableName());
            variable.setSyncronizing(true);
        }

        public void unsubscribeVariable(SharedVariableInterface variable)
        {
            variable.setSyncronizing(false);
        }

        public void pushVariable(SharedVariableInterface variable)
        {
            if (!variable.isSyncronizing())
            {
                return;
            }

            Message msg = MessageFactory.createVRB_REGISTRY_SET_VALUE(client.getSenderID(), SenderType.UNDEFINED,
                client.getPublicSession(),
                client.getClientID(), variable.getClassInstance(), variable.getVariableName(),
                variable.getAsTokenbuffer());
            client.sendMessage(msg);
        }

        public void pullVariable(SharedVariableInterface variable)
        {
//            throw new System.NotImplementedException();
        }
    }
}
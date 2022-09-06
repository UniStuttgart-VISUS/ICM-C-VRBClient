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
        }

        public void deleteVariable(SharedVariableInterface variable)
        {
 //           throw new System.NotImplementedException();
        }

        public void pushVariable(SharedVariableInterface variable)
        {
//            throw new System.NotImplementedException();
        }

        public void pullVariable(SharedVariableInterface variable)
        {
//            throw new System.NotImplementedException();
        }
    }
}
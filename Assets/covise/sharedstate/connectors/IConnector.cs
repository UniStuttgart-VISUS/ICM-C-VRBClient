using covise.networking;

namespace covise.sharedstate.connectors
{
    public interface IConnector
    {
        public void registerVariable(SharedVariableInterface variable);
        public void deleteVariable(SharedVariableInterface variable);
        
        public void pushVariable(SharedVariableInterface variable);
        public void pullVariable(SharedVariableInterface variable);
    }
}
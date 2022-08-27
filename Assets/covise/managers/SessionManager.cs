using System.Collections.Generic;
using covise.structs;

namespace covise.managers
{
    public class SessionManager
    {
        
        private Dictionary<int, SessionID> sessions;

        public SessionManager()
        {
            sessions = new Dictionary<int, SessionID>();
        }

        public void setSession(SessionID session)
        {
            sessions[session.owner] = session;
        }
        
        public void setSession(int id, SessionID session)
        {
            sessions[id] = session;
        }
        
        
    }
}
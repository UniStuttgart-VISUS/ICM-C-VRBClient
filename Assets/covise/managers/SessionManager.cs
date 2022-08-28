using System.Collections.Generic;
using System.Linq;
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

        public SessionID[] getSessions()
        {
            return sessions.Values.ToArray();
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
using System;
using System.Text;
using System.Threading.Tasks;
using covise.enums;
using covise.networking;
using covise.serialisation;
using covise.structs;
using UnityEngine;

namespace tests
{
    public class SessionTester: MonoBehaviour
    {
        [Header("Connection Settings")]
        public String host = "192.168.0.87";
        public int tcp_port = 31800;
        public int udp_port = 31801;

        [Header("User Data")] 
        public string username = "user";

        public string userEMail = "user@domain.invalid";
        public string url = "ist-n.eu";
        
        private VRBClient client;
        
        public void Start()
        {
            client = new VRBClient(host, tcp_port);
            client.setupDefaultHandlers();
            client.setUserInformation(username, userEMail, url);
            client.connect();
        }

        public void getTaskState () {
            Debug.Log(client.pollTask.Status);
            if (client.pollTask.Status == TaskStatus.Faulted)
            {
                Debug.LogError(client.pollTask.Exception);
            }
        }

        public void listSessions()
        {
            SessionID[] sessionIds = client.listSessions();

            StringBuilder sb = new StringBuilder();
            sb.Append("Available Sessions:\n");

            foreach (SessionID session in sessionIds)
            {
                sb.Append("\t");
                sb.Append(session.name);
                sb.Append("\n");
            }
            
            Debug.Log(sb.ToString());
        }

        public void createPublicSession()
        {
            client.createPublicSession("KolaBW Public Session");
        }

        public void registerValue()
        {
            TokenBuffer buffer = new TokenBuffer(true);
            buffer.append("VALUE");
            
            Message msg = MessageFactory.createVRB_REGISTRY_CREATE_ENTRY(client.getSenderID(), SenderType.UNDEFINED,
                client.getPublicSession(),
                client.getClientID(), "testclass", "var1", buffer, false);
            
            client.sendMessage(msg);
        }
    }
}
using System;
using System.Collections.Generic;
using covise.networking;
using covise.structs;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace tests
{
    public class ManagedClientTest : MonoBehaviour
    {
        [Header("Prefabs")]
        public GameObject buttonPrefab;
        public GameObject inputPrefab;
        public GameObject scrollareaPrefab;

        [Header("UI System")] 
        public Canvas canvas;

        public GameObject layoutGroup;
        
        public int lineHeight = 40;
        
        [Header("Default Presets")]
        public String host = "192.168.0.87";
        public int tcp_port = 31800;
        public int udp_port = 31801;

        public string username = "user";
        public string userEMail = "user@domain.invalid";
        public string url = "ist-n.eu";

        private Vector2 size;

        #region Connect Screen
        private GameObject ipInput;
        private GameObject portInput;
        private GameObject connectButton;
        
        private GameObject userInput;
        private GameObject mailInput;
        private GameObject domainInput;

        private List<GameObject> connectItems;
        #endregion

        #region Session Select Screen

        private GameObject sessionNameInput;
        private GameObject sessionRoot;
        
        private List<GameObject> sessionItems;
        private List<GameObject> availableSessions;
        #endregion

        protected ManagedVRBClient vrbClient;

        private volatile bool updateSessionList = false;
        
        public void Start()
        {
            vrbClient = new ManagedVRBClient(host, tcp_port);
            vrbClient.setupDefaultHandlers();

            vrbClient.onSessionListChanged += delegate(object sender, EventArgs args) {updateSessionList = true;};
            
            createConnectLayout();
            createSessionLayout();
            
            showConnectLayout();
        }

        public void Update()
        {
            if (updateSessionList)
            {
                clearLayout();
                showSessionLayout();
                updateSessionList = false;
            }
        }

        #region functions

        public void connect()
        {
            host = getText(ipInput);
            tcp_port = getInt(portInput);

            username = getText(userInput);
            userEMail = getText(mailInput);
            url = getText(domainInput);
            
            vrbClient.setAddress(host, tcp_port);
            vrbClient.setUserInformation(username, userEMail, url);
            vrbClient.connect();
            
            
        }

        public void createSession()
        {
            vrbClient.createPublicSession(getText(sessionNameInput));
            clearLayout();
        }

        public void joinSession(SessionID session)
        {
            Debug.Log("Joining existing Session: " + session.name);
            clearLayout();
        }

        #endregion

        #region uigetters

        public string getText(GameObject go)
        {
            return go.GetComponent<InputField>().text;
        }

        public int getInt(GameObject go)
        {
            return Int32.Parse(getText(go));
        }


        #endregion
        
        #region layouts

        public void showConnectLayout()
        {
            foreach (GameObject itm in connectItems)
            {
                itm.transform.SetParent(layoutGroup.transform);
            }
        }

        private void showSessionLayout()
        {
            refreshAvailableSessions();
            foreach (GameObject itm in sessionItems)
            {
                itm.transform.SetParent(layoutGroup.transform);
            }
        }
        
        public void clearLayout()
        {
            layoutGroup.transform.DetachChildren();
        }

        private void createConnectLayout()
        {
            connectItems = new List<GameObject>();

            GameObject addressGroup = createHorizontalLayout();
            
            //addressGroup.transform.SetParent(layoutGroup.transform);
            connectItems.Add(addressGroup);
            
            ipInput = Instantiate(inputPrefab);

            InputField ipField = ipInput.GetComponent<InputField>();
            ipField.text = host;
            
            ipInput.transform.SetParent(addressGroup.transform);
            
            portInput = Instantiate(inputPrefab);
            InputField portField = portInput.GetComponent<InputField>();
            portField.contentType = InputField.ContentType.IntegerNumber;
            portField.text = tcp_port.ToString();

            portInput.transform.SetParent(addressGroup.transform);

            connectButton = Instantiate(buttonPrefab);
            Button connectBtn = connectButton.GetComponent<Button>();
            connectBtn.GetComponentInChildren<Text>().text = "Connect";
            connectBtn.onClick.AddListener(connect);

            connectButton.transform.SetParent(addressGroup.transform);
            
            
            userInput = Instantiate(inputPrefab);
            InputField userField = userInput.GetComponent<InputField>();
            userField.text = username;

            //userInput.transform.SetParent(layoutGroup.transform);
            connectItems.Add(userInput);

            mailInput = Instantiate(inputPrefab);
            InputField mailField = mailInput.GetComponent<InputField>();
            mailField.text = userEMail;

            //mailInput.transform.SetParent(layoutGroup.transform);
            connectItems.Add(mailInput);

            domainInput = Instantiate(inputPrefab);
            InputField domainField = domainInput.GetComponent<InputField>();
            domainField.text = url;

            //domainInput.transform.SetParent(layoutGroup.transform);
            connectItems.Add(domainInput);
        }

        private void refreshAvailableSessions()
        {
            if (availableSessions == null)
            {
                availableSessions = new List<GameObject>();
            }

            for (int i = 0; i < availableSessions.Count; i++) {
                availableSessions[i].transform.SetParent(null);
                Destroy(availableSessions[i]);
            }
            
            availableSessions.Clear();

            SessionID[] sessions = vrbClient.listSessions();

            foreach (SessionID session in sessions)
            {  
                Debug.Log("Create Session Button: " + session.name);
                GameObject sessionBtn = createButton(session.name, () => { joinSession(session); });
                availableSessions.Add(sessionBtn);
                sessionBtn.transform.SetParent(sessionRoot.transform);
            }
        }

        private void createSessionLayout()
        {
            sessionItems = new List<GameObject>();
            availableSessions = new List<GameObject>();
            
            GameObject createGroup = createHorizontalLayout();
            sessionItems.Add(createGroup);
            
            sessionNameInput = createTextInputField("");
            sessionNameInput.transform.SetParent(createGroup.transform);

            GameObject createSessionBtn = createButton("Create new Session !", createSession);
            createSessionBtn.transform.SetParent(createGroup.transform);

            sessionRoot = createVerticalLayout();
            
            sessionItems.Add(sessionRoot);
        }
        
        private GameObject createHorizontalLayout()
        {
            GameObject addressGroup = new GameObject();
            HorizontalLayoutGroup addressLayout = addressGroup.AddComponent<HorizontalLayoutGroup>();
            addressLayout.childControlHeight = false;
            addressLayout.childControlWidth = false;

            return addressGroup;
        }

        private GameObject createVerticalLayout()
        {
            GameObject addressGroup = new GameObject();
            VerticalLayoutGroup addressLayout = addressGroup.AddComponent<VerticalLayoutGroup>();
            addressLayout.childControlHeight = false;
            addressLayout.childControlWidth = false;

            return addressGroup;
        }
        
        private GameObject createTextInputField(string text)
        {
            GameObject go = Instantiate(inputPrefab);
            InputField userField = go.GetComponent<InputField>();
            userField.text = text;

            //userInput.transform.SetParent(layoutGroup.transform);
 ;
            return go;
        }

        private GameObject createButton(string text, UnityAction action)
        {
            GameObject go = Instantiate(buttonPrefab);
            Button connectBtn = go.GetComponent<Button>();
            connectBtn.GetComponentInChildren<Text>().text = text;
            connectBtn.onClick.AddListener(action);

            return go;
        }

        #endregion

    }
}
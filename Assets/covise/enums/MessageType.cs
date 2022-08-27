namespace covise.enums
{
    public class MessageType
    {
        public const int ID_EMPTY = -1;
        public const int ID_MSG_FAILED = 0;
        public const int ID_MSG_OK = 1;
        public const int ID_INIT = 2;
        public const int ID_FINISHED = 3;
        public const int ID_SEND = 4;
        public const int ID_ALLOC = 5;
        public const int ID_UI = 6;
        public const int ID_APP_CONTACT_DM = 7;
        public const int ID_DM_CONTACT_DM = 8;
        public const int ID_SHM_MALLOC = 9;
        public const int ID_SHM_MALLOC_LIST = 10;
        public const int ID_MALLOC_OK = 11;
        public const int ID_MALLOC_LIST_OK = 12;
        public const int ID_MALLOC_FAILED = 13;
        public const int ID_PREPARE_CONTACT = 14;
        public const int ID_PREPARE_CONTACT_DM = 15;
        public const int ID_PORT = 16;
        public const int ID_GET_SHM_KEY = 17;
        public const int ID_NEW_OBJECT = 18;
        public const int ID_GET_OBJECT = 19;
        public const int ID_REGISTER_TYPE = 20;
        public const int ID_NEW_SDS = 21;
        public const int ID_SEND_ID = 22;
        public const int ID_ASK_FOR_OBJECT = 23;
        public const int ID_OBJECT_FOUND = 24;
        public const int ID_OBJECT_NOT_FOUND = 25;
        public const int ID_HAS_OBJECT_CHANGED = 26;
        public const int ID_OBJECT_UPDATE = 27;
        public const int ID_OBJECT_TRANSFER = 28;
        public const int ID_OBJECT_FOLLOWS = 29;
        public const int ID_OBJECT_OK = 30;
        public const int ID_CLOSE_SOCKET = 31;
        public const int ID_DESTROY_OBJECT = 32;
        public const int ID_CTRL_DESTROY_OBJECT = 33;
        public const int ID_QUIT = 34;
        public const int ID_START = 35;
        public const int ID_COVISE_ERROR = 36;
        public const int ID_INOBJ = 37;
        public const int ID_OUTOBJ = 38;
        public const int ID_OBJECT_NO_LONGER_USED = 39;
        public const int ID_SET_ACCESS = 40;
        public const int ID_FINALL = 41;
        public const int ID_ADD_OBJECT = 42;
        public const int ID_DELETE_OBJECT = 43;
        public const int ID_NEW_OBJECT_VERSION = 44;
        public const int ID_RENDER = 45;
        public const int ID_WAIT_CONTACT = 46;
        public const int ID_PARINFO = 47;
        public const int ID_MAKE_DATA_CONNECTION = 48;
        public const int ID_COMPLETE_DATA_CONNECTION = 49;
        public const int ID_SHM_FREE = 50;
        public const int ID_GET_TRANSFER_PORT = 51;
        public const int ID_TRANSFER_PORT = 52;
        public const int ID_CONNECT_TRANSFERMANAGER = 53;
        public const int ID_STDINOUT_EMPTY = 54;
        public const int ID_WARNING = 55;
        public const int ID_INFO = 56;
        public const int ID_REPLACE_OBJECT = 57;
        public const int ID_PLOT = 58;
        public const int ID_GET_LIST_OF_INTERFACES = 59;
        public const int ID_USR1 = 60;
        public const int ID_USR2 = 61;
        public const int ID_USR3 = 62;
        public const int ID_USR4 = 63;
        public const int ID_NEW_OBJECT_OK = 64;
        public const int ID_NEW_OBJECT_FAILED = 65;
        public const int ID_NEW_OBJECT_SHM_MALLOC_LIST = 66;
        public const int ID_REQ_UI = 67;
        public const int ID_NEW_PART_ADDED = 68;
        public const int ID_SENDING_NEW_PART = 69;
        public const int ID_FINPART = 70;
        public const int ID_NEW_PART_AVAILABLE =71;
        public const int ID_OBJECT_ON_HOSTS = 72;
        public const int ID_OBJECT_FOLLOWS_CONT = 73;
        public const int ID_CRB_EXEC = 74;
        public const int ID_COVISE_STOP_PIPELINE = 75;
        public const int ID_PREPARE_CONTACT_MODULE = 76;
        public const int ID_MODULE_CONTACT_MODULE = 77;
        public const int ID_SEND_APPL_PROCID = 78;
        public const int ID_INTERFACE_LIST = 79;
        public const int ID_MODULE_LIST = 80;
        public const int ID_HOSTID = 81;
        public const int ID_MODULE_STARTED = 82;
        public const int ID_GET_USER = 83;
        public const int ID_SOCKET_CLOSED = 84;
        public const int ID_NEW_COVISED = 85;
        public const int ID_USER_LIST = 86;
        public const int ID_STARTUP_INFO = 87;
        public const int ID_CO_MODULE = 88;
        public const int ID_WRITE_SCRIPT = 89;
        public const int ID_CRB = 90;
        public const int ID_GENERIC = 91;
        public const int ID_RENDER_MODULE = 92;
        public const int ID_FEEDBACK = 93;
        public const int ID_VRB_CONTACT = 94;
        public const int ID_VRB_CONNECT_TO_COVISE = 95;
        public const int ID_END_IMM_CB = 96;
        public const int ID_NEW_DESK = 97;
        public const int ID_VRB_SET_USERINFO = 98;
        public const int ID_VRB_GET_ID = 99;
        public const int ID_VRB_SET_GROUP = 100;
        public const int ID_VRB_QUIT = 101;
        public const int ID_VRB_SET_MASTER = 102;
        public const int ID_VRB_GUI = 103;
        public const int ID_VRB_CLOSE_VRB_CONNECTION = 104;
        public const int ID_VRB_REQUEST_FILE = 105;
        public const int ID_VRB_SEND_FILE = 106;
        public const int ID_VRB_CURRENT_FILE = 107;
        public const int ID_CRB_QUIT = 108;
        public const int ID_REMOVED_HOST = 109;
        public const int ID_START_COVER_SLAVE = 110;
        public const int ID_VRB_REGISTRY_ENTRY_CHANGED = 111;
        public const int ID_VRB_REGISTRY_ENTRY_DELETED = 112;
        public const int ID_VRB_REGISTRY_SUBSCRIBE_CLASS = 113;
        public const int ID_VRB_REGISTRY_SUBSCRIBE_VARIABLE = 114;
        public const int ID_VRB_REGISTRY_CREATE_ENTRY = 115;
        public const int ID_VRB_REGISTRY_SET_VALUE = 116;
        public const int ID_VRB_REGISTRY_DELETE_ENTRY = 117;
        public const int ID_VRB_REGISTRY_UNSUBSCRIBE_CLASS = 118;
        public const int ID_VRB_REGISTRY_UNSUBSCRIBE_VARIABLE = 119;
        public const int ID_SYNCHRONIZED_ACTION = 120;
        public const int ID_ACCESSGRID_DAEMON = 121;
        public const int ID_TABLET_UI = 122;
        public const int ID_QUERY_DATA_PATH = 123;
        public const int ID_SEND_DATA_PATH = 124;
        public const int ID_VRB_FB_RQ = 125;
        public const int ID_VRB_FB_SET = 126;
        public const int ID_VRB_FB_REMREQ = 127;
        public const int ID_UPDATE_LOADED_MAPNAME = 128;
        public const int ID_SSLDAEMON = 129;
        public const int ID_VISENSO_UI = 130;
        public const int ID_PARAMDESC = 131;
        public const int ID_VRB_REQUEST_NEW_SESSION = 132;
        public const int ID_VRBC_SET_SESSION = 133;
        public const int ID_VRBC_SEND_SESSIONS = 134;
        public const int ID_VRBC_CHANGE_SESSION = 135;
        public const int ID_VRBC_UNOBSERVE_SESSION = 136;
        public const int ID_VRB_SAVE_SESSION = 137;
        public const int ID_VRB_LOAD_SESSION = 138;
        public const int ID_VRB_MESSAGE = 139;
        public const int ID_VRB_PERMIT_LAUNCH = 140;
        public const int ID_BROADCAST_TO_PROGRAM = 141;
        public const int ID_NEW_UI = 142;
        public const int ID_PROXY = 143;
        public const int ID_SOUND = 144;
        public const int ID_LAST_DUMMY_MESSAGE = 145;

        
        public static readonly MessageType EMPTY = new MessageType(ID_EMPTY, "EMPTY");
        public static readonly MessageType MSG_FAILED = new MessageType(ID_MSG_FAILED, "MSG_FAILED");
        public static readonly MessageType MSG_OK = new MessageType(ID_MSG_OK, "MSG_OK");
        public static readonly MessageType INIT = new MessageType(ID_INIT, "INIT");
        public static readonly MessageType FINISHED = new MessageType(ID_FINISHED, "FINISHED");
        public static readonly MessageType SEND = new MessageType(ID_SEND, "SEND");
        public static readonly MessageType ALLOC = new MessageType(ID_ALLOC, "ALLOC");
        public static readonly MessageType UI = new MessageType(ID_UI, "UI");
        public static readonly MessageType APP_CONTACT_DM = new MessageType(ID_APP_CONTACT_DM, "APP_CONTACT_DM");
        public static readonly MessageType DM_CONTACT_DM = new MessageType(ID_DM_CONTACT_DM, "DM_CONTACT_DM");
        public static readonly MessageType SHM_MALLOC = new MessageType(ID_SHM_MALLOC, "SHM_MALLOC");
        public static readonly MessageType SHM_MALLOC_LIST = new MessageType(ID_SHM_MALLOC_LIST, "SHM_MALLOC_LIST");
        public static readonly MessageType MALLOC_OK = new MessageType(ID_MALLOC_OK, "MALLOC_OK");
        public static readonly MessageType MALLOC_LIST_OK = new MessageType(ID_MALLOC_LIST_OK, "MALLOC_LIST_OK");
        public static readonly MessageType MALLOC_FAILED = new MessageType(ID_MALLOC_FAILED, "MALLOC_FAILED");
        public static readonly MessageType PREPARE_CONTACT = new MessageType(ID_PREPARE_CONTACT, "PREPARE_CONTACT");
        public static readonly MessageType PREPARE_CONTACT_DM = new MessageType(ID_PREPARE_CONTACT_DM, "PREPARE_CONTACT_DM");
        public static readonly MessageType PORT = new MessageType(ID_PORT, "PORT");
        public static readonly MessageType GET_SHM_KEY = new MessageType(ID_GET_SHM_KEY, "GET_SHM_KEY");
        public static readonly MessageType NEW_OBJECT = new MessageType(ID_NEW_OBJECT, "NEW_OBJECT");
        public static readonly MessageType GET_OBJECT = new MessageType(ID_GET_OBJECT, "GET_OBJECT");
        public static readonly MessageType REGISTER_TYPE = new MessageType(ID_REGISTER_TYPE, "REGISTER_TYPE");
        public static readonly MessageType NEW_SDS = new MessageType(ID_NEW_SDS, "NEW_SDS");
        public static readonly MessageType SEND_ID = new MessageType(ID_SEND_ID, "SEND_ID");
        public static readonly MessageType ASK_FOR_OBJECT = new MessageType(ID_ASK_FOR_OBJECT, "ASK_FOR_OBJECT");
        public static readonly MessageType OBJECT_FOUND = new MessageType(ID_OBJECT_FOUND, "OBJECT_FOUND");
        public static readonly MessageType OBJECT_NOT_FOUND = new MessageType(ID_OBJECT_NOT_FOUND, "OBJECT_NOT_FOUND");
        public static readonly MessageType HAS_OBJECT_CHANGED = new MessageType(ID_HAS_OBJECT_CHANGED, "HAS_OBJECT_CHANGED");
        public static readonly MessageType OBJECT_UPDATE = new MessageType(ID_OBJECT_UPDATE, "OBJECT_UPDATE");
        public static readonly MessageType OBJECT_TRANSFER = new MessageType(ID_OBJECT_TRANSFER, "OBJECT_TRANSFER");
        public static readonly MessageType OBJECT_FOLLOWS = new MessageType(ID_OBJECT_FOLLOWS, "OBJECT_FOLLOWS");
        public static readonly MessageType OBJECT_OK = new MessageType(ID_OBJECT_OK, "OBJECT_OK");
        public static readonly MessageType CLOSE_SOCKET = new MessageType(ID_CLOSE_SOCKET, "CLOSE_SOCKET");
        public static readonly MessageType DESTROY_OBJECT = new MessageType(ID_DESTROY_OBJECT, "DESTROY_OBJECT");
        public static readonly MessageType CTRL_DESTROY_OBJECT = new MessageType(ID_CTRL_DESTROY_OBJECT, "CTRL_DESTROY_OBJECT");
        public static readonly MessageType QUIT = new MessageType(ID_QUIT, "QUIT");
        public static readonly MessageType START = new MessageType(ID_START, "START");
        public static readonly MessageType COVISE_ERROR = new MessageType(ID_COVISE_ERROR, "COVISE_ERROR");
        public static readonly MessageType INOBJ = new MessageType(ID_INOBJ, "INOBJ");
        public static readonly MessageType OUTOBJ = new MessageType(ID_OUTOBJ, "OUTOBJ");
        public static readonly MessageType OBJECT_NO_LONGER_USED = new MessageType(ID_OBJECT_NO_LONGER_USED, "OBJECT_NO_LONGER_USED");
        public static readonly MessageType SET_ACCESS = new MessageType(ID_SET_ACCESS, "SET_ACCESS");
        public static readonly MessageType FINALL = new MessageType(ID_FINALL, "FINALL");
        public static readonly MessageType ADD_OBJECT = new MessageType(ID_ADD_OBJECT, "ADD_OBJECT");
        public static readonly MessageType DELETE_OBJECT = new MessageType(ID_DELETE_OBJECT, "DELETE_OBJECT");
        public static readonly MessageType NEW_OBJECT_VERSION = new MessageType(ID_NEW_OBJECT_VERSION, "NEW_OBJECT_VERSION");
        public static readonly MessageType RENDER = new MessageType(ID_RENDER, "RENDER");
        public static readonly MessageType WAIT_CONTACT = new MessageType(ID_WAIT_CONTACT, "WAIT_CONTACT");
        public static readonly MessageType PARINFO = new MessageType(ID_PARINFO, "PARINFO");
        public static readonly MessageType MAKE_DATA_CONNECTION = new MessageType(ID_MAKE_DATA_CONNECTION, "MAKE_DATA_CONNECTION");
        public static readonly MessageType COMPLETE_DATA_CONNECTION = new MessageType(ID_COMPLETE_DATA_CONNECTION, "COMPLETE_DATA_CONNECTION");
        public static readonly MessageType SHM_FREE = new MessageType(ID_SHM_FREE, "SHM_FREE");
        public static readonly MessageType GET_TRANSFER_PORT = new MessageType(ID_GET_TRANSFER_PORT, "GET_TRANSFER_PORT");
        public static readonly MessageType TRANSFER_PORT = new MessageType(ID_TRANSFER_PORT, "TRANSFER_PORT");
        public static readonly MessageType CONNECT_TRANSFERMANAGER = new MessageType(ID_CONNECT_TRANSFERMANAGER, "CONNECT_TRANSFERMANAGER");
        public static readonly MessageType STDINOUT_EMPTY = new MessageType(ID_STDINOUT_EMPTY, "STDINOUT_EMPTY");
        public static readonly MessageType WARNING = new MessageType(ID_WARNING, "WARNING");
        public static readonly MessageType INFO = new MessageType(ID_INFO, "INFO");
        public static readonly MessageType REPLACE_OBJECT = new MessageType(ID_REPLACE_OBJECT, "REPLACE_OBJECT");
        public static readonly MessageType PLOT = new MessageType(ID_PLOT, "PLOT");
        public static readonly MessageType GET_LIST_OF_INTERFACES = new MessageType(ID_GET_LIST_OF_INTERFACES, "GET_LIST_OF_INTERFACES");
        public static readonly MessageType USR1 = new MessageType(ID_USR1, "USR1");
        public static readonly MessageType USR2 = new MessageType(ID_USR2, "USR2");
        public static readonly MessageType USR3 = new MessageType(ID_USR3, "USR3");
        public static readonly MessageType USR4 = new MessageType(ID_USR4, "USR4");
        public static readonly MessageType NEW_OBJECT_OK = new MessageType(ID_NEW_OBJECT_OK, "NEW_OBJECT_OK");
        public static readonly MessageType NEW_OBJECT_FAILED = new MessageType(ID_NEW_OBJECT_FAILED, "NEW_OBJECT_FAILED");
        public static readonly MessageType NEW_OBJECT_SHM_MALLOC_LIST = new MessageType(ID_NEW_OBJECT_SHM_MALLOC_LIST, "NEW_OBJECT_SHM_MALLOC_LIST");
        public static readonly MessageType REQ_UI = new MessageType(ID_REQ_UI, "REQ_UI");
        public static readonly MessageType NEW_PART_ADDED = new MessageType(ID_NEW_PART_ADDED, "NEW_PART_ADDED");
        public static readonly MessageType SENDING_NEW_PART = new MessageType(ID_SENDING_NEW_PART, "SENDING_NEW_PART");
        public static readonly MessageType FINPART = new MessageType(ID_FINPART, "FINPART");
        public static readonly MessageType NEW_PART_AVAILABLE = new MessageType(ID_NEW_PART_AVAILABLE, "NEW_PART_AVAILABLE");
        public static readonly MessageType OBJECT_ON_HOSTS = new MessageType(ID_OBJECT_ON_HOSTS, "OBJECT_ON_HOSTS");
        public static readonly MessageType OBJECT_FOLLOWS_CONT = new MessageType(ID_OBJECT_FOLLOWS_CONT, "OBJECT_FOLLOWS_CONT");
        public static readonly MessageType CRB_EXEC = new MessageType(ID_CRB_EXEC, "CRB_EXEC");
        public static readonly MessageType COVISE_STOP_PIPELINE = new MessageType(ID_COVISE_STOP_PIPELINE, "COVISE_STOP_PIPELINE");
        public static readonly MessageType PREPARE_CONTACT_MODULE = new MessageType(ID_PREPARE_CONTACT_MODULE, "PREPARE_CONTACT_MODULE");
        public static readonly MessageType MODULE_CONTACT_MODULE = new MessageType(ID_MODULE_CONTACT_MODULE, "MODULE_CONTACT_MODULE");
        public static readonly MessageType SEND_APPL_PROCID = new MessageType(ID_SEND_APPL_PROCID, "SEND_APPL_PROCID");
        public static readonly MessageType INTERFACE_LIST = new MessageType(ID_INTERFACE_LIST, "INTERFACE_LIST");
        public static readonly MessageType MODULE_LIST = new MessageType(ID_MODULE_LIST, "MODULE_LIST");
        public static readonly MessageType HOSTID = new MessageType(ID_HOSTID, "HOSTID");
        public static readonly MessageType MODULE_STARTED = new MessageType(ID_MODULE_STARTED, "MODULE_STARTED");
        public static readonly MessageType GET_USER = new MessageType(ID_GET_USER, "GET_USER");
        public static readonly MessageType SOCKET_CLOSED = new MessageType(ID_SOCKET_CLOSED, "SOCKET_CLOSED");
        public static readonly MessageType NEW_COVISED = new MessageType(ID_NEW_COVISED, "NEW_COVISED");
        public static readonly MessageType USER_LIST = new MessageType(ID_USER_LIST, "USER_LIST");
        public static readonly MessageType STARTUP_INFO = new MessageType(ID_STARTUP_INFO, "STARTUP_INFO");
        public static readonly MessageType CO_MODULE = new MessageType(ID_CO_MODULE, "CO_MODULE");
        public static readonly MessageType WRITE_SCRIPT = new MessageType(ID_WRITE_SCRIPT, "WRITE_SCRIPT");
        public static readonly MessageType CRB = new MessageType(ID_CRB, "CRB");
        public static readonly MessageType GENERIC = new MessageType(ID_GENERIC, "GENERIC");
        public static readonly MessageType RENDER_MODULE = new MessageType(ID_RENDER_MODULE, "RENDER_MODULE");
        public static readonly MessageType FEEDBACK = new MessageType(ID_FEEDBACK, "FEEDBACK");
        public static readonly MessageType VRB_CONTACT = new MessageType(ID_VRB_CONTACT, "VRB_CONTACT");
        public static readonly MessageType VRB_CONNECT_TO_COVISE = new MessageType(ID_VRB_CONNECT_TO_COVISE, "VRB_CONNECT_TO_COVISE");
        public static readonly MessageType END_IMM_CB = new MessageType(ID_END_IMM_CB, "END_IMM_CB");
        public static readonly MessageType NEW_DESK = new MessageType(ID_NEW_DESK, "NEW_DESK");
        public static readonly MessageType VRB_SET_USERINFO = new MessageType(ID_VRB_SET_USERINFO, "VRB_SET_USERINFO");
        public static readonly MessageType VRB_GET_ID = new MessageType(ID_VRB_GET_ID, "VRB_GET_ID");
        public static readonly MessageType VRB_SET_GROUP = new MessageType(ID_VRB_SET_GROUP, "VRB_SET_GROUP");
        public static readonly MessageType VRB_QUIT = new MessageType(ID_VRB_QUIT, "VRB_QUIT");
        public static readonly MessageType VRB_SET_MASTER = new MessageType(ID_VRB_SET_MASTER, "VRB_SET_MASTER");
        public static readonly MessageType VRB_GUI = new MessageType(ID_VRB_GUI, "VRB_GUI");
        public static readonly MessageType VRB_CLOSE_VRB_CONNECTION = new MessageType(ID_VRB_CLOSE_VRB_CONNECTION, "VRB_CLOSE_VRB_CONNECTION");
        public static readonly MessageType VRB_REQUEST_FILE = new MessageType(ID_VRB_REQUEST_FILE, "VRB_REQUEST_FILE");
        public static readonly MessageType VRB_SEND_FILE = new MessageType(ID_VRB_SEND_FILE, "VRB_SEND_FILE");
        public static readonly MessageType VRB_CURRENT_FILE = new MessageType(ID_VRB_CURRENT_FILE, "VRB_CURRENT_FILE");
        public static readonly MessageType CRB_QUIT = new MessageType(ID_CRB_QUIT, "CRB_QUIT");
        public static readonly MessageType REMOVED_HOST = new MessageType(ID_REMOVED_HOST, "REMOVED_HOST");
        public static readonly MessageType START_COVER_SLAVE = new MessageType(ID_START_COVER_SLAVE, "START_COVER_SLAVE");
        public static readonly MessageType VRB_REGISTRY_ENTRY_CHANGED = new MessageType(ID_VRB_REGISTRY_ENTRY_CHANGED, "VRB_REGISTRY_ENTRY_CHANGED");
        public static readonly MessageType VRB_REGISTRY_ENTRY_DELETED = new MessageType(ID_VRB_REGISTRY_ENTRY_DELETED, "VRB_REGISTRY_ENTRY_DELETED");
        public static readonly MessageType VRB_REGISTRY_SUBSCRIBE_CLASS = new MessageType(ID_VRB_REGISTRY_SUBSCRIBE_CLASS, "VRB_REGISTRY_SUBSCRIBE_CLASS");
        public static readonly MessageType VRB_REGISTRY_SUBSCRIBE_VARIABLE = new MessageType(ID_VRB_REGISTRY_SUBSCRIBE_VARIABLE, "VRB_REGISTRY_SUBSCRIBE_VARIABLE");
        public static readonly MessageType VRB_REGISTRY_CREATE_ENTRY = new MessageType(ID_VRB_REGISTRY_CREATE_ENTRY, "VRB_REGISTRY_CREATE_ENTRY");
        public static readonly MessageType VRB_REGISTRY_SET_VALUE = new MessageType(ID_VRB_REGISTRY_SET_VALUE, "VRB_REGISTRY_SET_VALUE");
        public static readonly MessageType VRB_REGISTRY_DELETE_ENTRY = new MessageType(ID_VRB_REGISTRY_DELETE_ENTRY, "VRB_REGISTRY_DELETE_ENTRY");
        public static readonly MessageType VRB_REGISTRY_UNSUBSCRIBE_CLASS = new MessageType(ID_VRB_REGISTRY_UNSUBSCRIBE_CLASS, "VRB_REGISTRY_UNSUBSCRIBE_CLASS");
        public static readonly MessageType VRB_REGISTRY_UNSUBSCRIBE_VARIABLE = new MessageType(ID_VRB_REGISTRY_UNSUBSCRIBE_VARIABLE, "VRB_REGISTRY_UNSUBSCRIBE_VARIABLE");
        public static readonly MessageType SYNCHRONIZED_ACTION = new MessageType(ID_SYNCHRONIZED_ACTION, "SYNCHRONIZED_ACTION");
        public static readonly MessageType ACCESSGRID_DAEMON = new MessageType(ID_ACCESSGRID_DAEMON, "ACCESSGRID_DAEMON");
        public static readonly MessageType TABLET_UI = new MessageType(ID_TABLET_UI, "TABLET_UI");
        public static readonly MessageType QUERY_DATA_PATH = new MessageType(ID_QUERY_DATA_PATH, "QUERY_DATA_PATH");
        public static readonly MessageType SEND_DATA_PATH = new MessageType(ID_SEND_DATA_PATH, "SEND_DATA_PATH");
        public static readonly MessageType VRB_FB_RQ = new MessageType(ID_VRB_FB_RQ, "VRB_FB_RQ");
        public static readonly MessageType VRB_FB_SET = new MessageType(ID_VRB_FB_SET, "VRB_FB_SET");
        public static readonly MessageType VRB_FB_REMREQ = new MessageType(ID_VRB_FB_REMREQ, "VRB_FB_REMREQ");
        public static readonly MessageType UPDATE_LOADED_MAPNAME = new MessageType(ID_UPDATE_LOADED_MAPNAME, "UPDATE_LOADED_MAPNAME");
        public static readonly MessageType SSLDAEMON = new MessageType(ID_SSLDAEMON, "SSLDAEMON");
        public static readonly MessageType VISENSO_UI = new MessageType(ID_VISENSO_UI, "VISENSO_UI");
        public static readonly MessageType PARAMDESC = new MessageType(ID_PARAMDESC, "PARAMDESC");
        public static readonly MessageType VRB_REQUEST_NEW_SESSION = new MessageType(ID_VRB_REQUEST_NEW_SESSION, "VRB_REQUEST_NEW_SESSION");
        public static readonly MessageType VRBC_SET_SESSION = new MessageType(ID_VRBC_SET_SESSION, "VRBC_SET_SESSION");
        public static readonly MessageType VRBC_SEND_SESSIONS = new MessageType(ID_VRBC_SEND_SESSIONS, "VRBC_SEND_SESSIONS");
        public static readonly MessageType VRBC_CHANGE_SESSION = new MessageType(ID_VRBC_CHANGE_SESSION, "VRBC_CHANGE_SESSION");
        public static readonly MessageType VRBC_UNOBSERVE_SESSION = new MessageType(ID_VRBC_UNOBSERVE_SESSION, "VRBC_UNOBSERVE_SESSION");
        public static readonly MessageType VRB_SAVE_SESSION = new MessageType(ID_VRB_SAVE_SESSION, "VRB_SAVE_SESSION");
        public static readonly MessageType VRB_LOAD_SESSION = new MessageType(ID_VRB_LOAD_SESSION, "VRB_LOAD_SESSION");
        public static readonly MessageType VRB_MESSAGE = new MessageType(ID_VRB_MESSAGE, "VRB_MESSAGE");
        public static readonly MessageType VRB_PERMIT_LAUNCH = new MessageType(ID_VRB_PERMIT_LAUNCH, "VRB_PERMIT_LAUNCH");
        public static readonly MessageType BROADCAST_TO_PROGRAM = new MessageType(ID_BROADCAST_TO_PROGRAM, "BROADCAST_TO_PROGRAM");
        public static readonly MessageType NEW_UI = new MessageType(ID_NEW_UI, "NEW_UI");
        public static readonly MessageType PROXY = new MessageType(ID_PROXY, "PROXY");
        public static readonly MessageType SOUND = new MessageType(ID_SOUND, "SOUND");
        public static readonly MessageType LAST_DUMMY_MESSAGE = new MessageType(ID_LAST_DUMMY_MESSAGE, "LAST_DUMMY_MESSAGE");

        public static readonly MessageType[] values = new[]
        {
            EMPTY,
            MSG_FAILED,
            MSG_OK,
            INIT,
            FINISHED,
            SEND,
            ALLOC,
            UI,
            APP_CONTACT_DM,
            DM_CONTACT_DM,
            SHM_MALLOC,
            SHM_MALLOC_LIST,
            MALLOC_OK,
            MALLOC_LIST_OK,
            MALLOC_FAILED,
            PREPARE_CONTACT,
            PREPARE_CONTACT_DM,
            PORT,
            GET_SHM_KEY,
            NEW_OBJECT,
            GET_OBJECT,
            REGISTER_TYPE,
            NEW_SDS,
            SEND_ID,
            ASK_FOR_OBJECT,
            OBJECT_FOUND,
            OBJECT_NOT_FOUND,
            HAS_OBJECT_CHANGED,
            OBJECT_UPDATE,
            OBJECT_TRANSFER,
            OBJECT_FOLLOWS,
            OBJECT_OK,
            CLOSE_SOCKET,
            DESTROY_OBJECT,
            CTRL_DESTROY_OBJECT,
            QUIT,
            START,
            COVISE_ERROR,
            INOBJ,
            OUTOBJ,
            OBJECT_NO_LONGER_USED,
            SET_ACCESS,
            FINALL,
            ADD_OBJECT,
            DELETE_OBJECT,
            NEW_OBJECT_VERSION,
            RENDER,
            WAIT_CONTACT,
            PARINFO,
            MAKE_DATA_CONNECTION,
            COMPLETE_DATA_CONNECTION,
            SHM_FREE,
            GET_TRANSFER_PORT,
            TRANSFER_PORT,
            CONNECT_TRANSFERMANAGER,
            STDINOUT_EMPTY,
            WARNING,
            INFO,
            REPLACE_OBJECT,
            PLOT,
            GET_LIST_OF_INTERFACES,
            USR1,
            USR2,
            USR3,
            USR4,
            NEW_OBJECT_OK,
            NEW_OBJECT_FAILED,
            NEW_OBJECT_SHM_MALLOC_LIST,
            REQ_UI,
            NEW_PART_ADDED,
            SENDING_NEW_PART,
            FINPART,
            NEW_PART_AVAILABLE,
            OBJECT_ON_HOSTS,
            OBJECT_FOLLOWS_CONT,
            CRB_EXEC,
            COVISE_STOP_PIPELINE,
            PREPARE_CONTACT_MODULE,
            MODULE_CONTACT_MODULE,
            SEND_APPL_PROCID,
            INTERFACE_LIST,
            MODULE_LIST,
            HOSTID,
            MODULE_STARTED,
            GET_USER,
            SOCKET_CLOSED,
            NEW_COVISED,
            USER_LIST,
            STARTUP_INFO,
            CO_MODULE,
            WRITE_SCRIPT,
            CRB,
            GENERIC,
            RENDER_MODULE,
            FEEDBACK,
            VRB_CONTACT,
            VRB_CONNECT_TO_COVISE,
            END_IMM_CB,
            NEW_DESK,
            VRB_SET_USERINFO,
            VRB_GET_ID,
            VRB_SET_GROUP,
            VRB_QUIT,
            VRB_SET_MASTER,
            VRB_GUI,
            VRB_CLOSE_VRB_CONNECTION,
            VRB_REQUEST_FILE,
            VRB_SEND_FILE,
            VRB_CURRENT_FILE,
            CRB_QUIT,
            REMOVED_HOST,
            START_COVER_SLAVE,
            VRB_REGISTRY_ENTRY_CHANGED,
            VRB_REGISTRY_ENTRY_DELETED,
            VRB_REGISTRY_SUBSCRIBE_CLASS,
            VRB_REGISTRY_SUBSCRIBE_VARIABLE,
            VRB_REGISTRY_CREATE_ENTRY,
            VRB_REGISTRY_SET_VALUE,
            VRB_REGISTRY_DELETE_ENTRY,
            VRB_REGISTRY_UNSUBSCRIBE_CLASS,
            VRB_REGISTRY_UNSUBSCRIBE_VARIABLE,
            SYNCHRONIZED_ACTION,
            ACCESSGRID_DAEMON,
            TABLET_UI,
            QUERY_DATA_PATH,
            SEND_DATA_PATH,
            VRB_FB_RQ,
            VRB_FB_SET,
            VRB_FB_REMREQ,
            UPDATE_LOADED_MAPNAME,
            SSLDAEMON,
            VISENSO_UI,
            PARAMDESC,
            VRB_REQUEST_NEW_SESSION,
            VRBC_SET_SESSION,
            VRBC_SEND_SESSIONS,
            VRBC_CHANGE_SESSION,
            VRBC_UNOBSERVE_SESSION,
            VRB_SAVE_SESSION,
            VRB_LOAD_SESSION,
            VRB_MESSAGE,
            VRB_PERMIT_LAUNCH,
            BROADCAST_TO_PROGRAM,
            NEW_UI,
            PROXY,
            SOUND,
            LAST_DUMMY_MESSAGE
        };
        
        public readonly int value;
        public readonly string name;
        
        private MessageType(int value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public static MessageType fromID(int idx)
        {
            return values[idx +1]; // +1 to account for offset (first messagetype is -1 and not 0)
        }

        public static string[] listNames()
        {
            string[] names = new string[values.Length];
            
            for (int i = 0; i < values.Length; i++)
            {
                names[i] = values[i].name;
            }

            return names;
        }
        
        public override string ToString()
        {
            return name + " (" + value + ")";
        }
    }
}
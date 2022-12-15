using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
// using Unity.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


[System.Serializable]
public class DefaultRoom
{
    public string Name;
    public string SceneName;
    public int maxPlayer;
}

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private int PlayerNumInRoom = 0;
    public static NetworkManager Instance;
    public List<DefaultRoom> defaultRooms;
    public string PlayerName;
    public int PlayerNum = 0;
    DefaultRoom roomSettings;
    public GameObject RoomUI;
    public GameObject GameUI;

    public Text ServerStatus;
    public Text YourStatus;


    private GameObject spawnedPlayerPrefab;
    private GameObject HapticDevicePrefab;
    public GameObject MainCamera;
    public GameObject XRRig;
    public GameObject HapticDevice;

    private bool isNetworkConnected;

    private PhotonView photonView;
    private void Awake()
    {
        var objs = FindObjectsOfType<NetworkManager>();
        if(objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if(XRRig.activeSelf == false)
        {
            MainCamera.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        //ConnectToServer();
        roomSettings = defaultRooms[0];
        //PlayerName = defaultRooms[0].pl;
        //Debug.Log(NetworkManager.Instance.PlayerName + " : Name");
        photonView = GetComponent<PhotonView>();

    }

    private void Update()
    {
        PlayerNumInRoom = PhotonNetwork.CountOfPlayersOnMaster;
        //Debug.Log($"Player Num In Room: {PlayerNumInRoom}");
        checkHapticLocation();
        if(isNetworkConnected == true)
        {
            if (photonView.IsMine)
            {
                YourStatus.text = "Master";
            }
            else
            {
                YourStatus.text = "Client";
            }
        }
    }

    public void ConnectToServer(){
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try to connect to server...");
        ServerStatus.text = "Connecting...";
    }

    public void InitializeRoom(string sPlayerName){
        //DefaultRoom roomSettings = defaultRooms[0];
        //PlayerName = sPlayerName;
        //Debug.Log(NetworkManager.Instance.PlayerName+" : Name");

        
        //Create the room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }
    public void Btn_ChoosePlayerEnterRoom(string playerName)
    {
        if (PhotonNetwork.InLobby)
        {
            NetworkManager.Instance.PlayerName = playerName;
            Debug.Log($"{NetworkManager.Instance.PlayerName} Joined The Lobby. Initialize Room");
            InitializeRoom(NetworkManager.Instance.PlayerName);
        }
        else
        {
            Debug.LogWarning("Please Connect your Server First");
        }
    }
    public override void OnJoinedLobby(){
        Debug.Log("We Joined The Lobby");
        ServerStatus.text = "Choose your player";//Joined The Lobby. Please 
        base.OnJoinedLobby();
        //InitializeRoom(NetworkManager.Instance.PlayerName);
       //RoomUI.SetActive(true);
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to Server");
        ServerStatus.text = "Connected to Server";
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
       
    }

    public override void OnJoinedRoom(){
        //PlayerNumInRoom = PhotonNetwork.CountOfPlayers;
        //PlayerNumInRoom++;
        //NetworkManager.Instance.PlayerName = "Player"+ PlayerNumInRoom.ToString();
        //Debug.Log($"PlayerName: {NetworkManager.Instance.PlayerName}");
        //Load Scene
        //PhotonNetwork.LoadLevel(roomSettings.SceneName);

        Debug.Log($"Joined the Room. Player Num In Room: {PlayerNumInRoom}");
        RoomUI.SetActive(false);
        GameUI.SetActive(true);
        isNetworkConnected = true;
        //Debug.Log("Joined a Room");
        base.OnJoinedRoom();

        //Debug.Log(NetworkManager.Instance.PlayerName+" Joined");
        if(NetworkManager.Instance.PlayerName == "Player1")
        {
            Debug.Log(NetworkManager.Instance.PlayerName + " Joined");
            //XRRig = GameObject.FindGameObjectWithTag("XRTag");
            Debug.Log(XRRig);
            //XRRig = GameObject.Find("XR Origin");
            //XROrigin rig = FindObjectOfType<XROrigin>();
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetWorkPlayer", transform.position, transform.rotation);
            //HapticDevicePrefab = PhotonNetwork.Instantiate("HapticDevice (1)", transform.position, transform.rotation);
            //Oculus
            if (XRRig != null)
            {
                XRRig.transform.position = new Vector3(-0.025f, 1f, -1.858f);
                XRRig.transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log($"Found XR Origin & Pos: {XRRig.transform.position}");
            }
            //HapticDevice
            if (HapticDevice != null)
            {
                HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, -0.41f);
                HapticDevice.transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
            }//HapticDevice
            //if (HapticDevice != null)
            //{
            //    HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, -0.41f);
            //    HapticDevice.transform.rotation = Quaternion.Euler(0, 0, 0);
            //    Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
            //}
        }
        else if(NetworkManager.Instance.PlayerName == "Player2")
        {
            Debug.Log(NetworkManager.Instance.PlayerName + " Joined");
            //XRRig = GameObject.FindGameObjectWithTag("XRTag");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetWorkPlayer", transform.position, transform.rotation);
            //HapticDevicePrefab = PhotonNetwork.Instantiate("HapticDevice (2)", transform.position, transform.rotation);

            Debug.Log(XRRig);
            if (XRRig != null)
            {
                XRRig.transform.position = new Vector3(0.008f, 1f, 3.655f);
                XRRig.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Debug.Log($"Found XR Origin & Pos: {XRRig.transform.position}");
                //spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetWorkPlayer", transform.position, transform.rotation);
            }
            //HapticDevice
            if (HapticDevice != null)
            {
                HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, 2.11f);
                HapticDevice.transform.rotation = Quaternion.Euler(0, 180f, 0);
                //Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
            }
            //if (HapticDevice != null)
            //{
            //    HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, 2.11f);
            //    HapticDevice.transform.rotation = Quaternion.Euler(0, 180f, 0);
            //    Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
            //}
        }
        else{
            Debug.Log("Wrong Plyaer Clicked");
            //spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, new Vector3(1, 1.1f, -1.6f), Quaternion.Euler(0, 0, 0));
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) { //NetworkPlayer
        Debug.Log($"A new player Joined the room: {PlayerNumInRoom}");
        base.OnPlayerEnteredRoom(newPlayer);
        
    }
    public override void OnLeftRoom(){
        PlayerNumInRoom--;
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }

    private void checkHapticLocation()
    {
        if (NetworkManager.Instance.PlayerName == "Player1")
        {
            if(HapticDevice.transform.position != new Vector3(-0.07f, 1.9f, -0.41f))
            {
                //Debug.Log("Player1's hatpic location is wrong");
                //HapticDevice
                if (HapticDevice != null)
                {
                    HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, -0.41f);
                    HapticDevice.transform.rotation = Quaternion.Euler(0, 0, 0);
                    //Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
                }//HapticDevice
            }
            else
            {
                //Debug.Log("Player1's hatpic location is Okay");
            }


        }
        else if (NetworkManager.Instance.PlayerName == "Player2")
        {
            //HapticDevice
            if (HapticDevice.transform.position != new Vector3(-0.07f, 1.9f, 2.11f))
            {
                //Debug.Log("Player2's hatpic location is wrong");

                if (HapticDevice != null)
                {
                    HapticDevice.transform.position = new Vector3(-0.07f, 1.9f, 2.11f);
                    HapticDevice.transform.rotation = Quaternion.Euler(0, 180f, 0);
                    //Debug.Log($"Found HapticDevice & Pos: {HapticDevice.transform.position}");
                }
            }
            else
            {
                //Debug.Log("Player2's hatpic location is Okay");
            }

        }
    }

}

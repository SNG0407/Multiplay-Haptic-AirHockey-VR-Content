using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
// using Unity.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using Photon.Pun;
using Photon.Realtime;



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

    private GameObject spawnedPlayerPrefab;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ConnectToServer();
        roomSettings = defaultRooms[0];
        //PlayerName = defaultRooms[0].pl;
        //Debug.Log(NetworkManager.Instance.PlayerName + " : Name");

    }

    private void Update()
    {
        PlayerNumInRoom = PhotonNetwork.CountOfPlayersOnMaster;
        //Debug.Log($"Player Num In Room: {PlayerNumInRoom}");
    }

    public void ConnectToServer(){
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try to connect to server...");
    }

    public void InitializeRoom(string sPlayerName){
        //DefaultRoom roomSettings = defaultRooms[0];
        //PlayerName = sPlayerName;
        //Debug.Log(NetworkManager.Instance.PlayerName+" : Name");

        //Load Scene
        //PhotonNetwork.LoadLevel(roomSettings.SceneName);
        //Create the room
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)roomSettings.maxPlayer;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(roomSettings.Name, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedLobby(){
        Debug.Log("We Joined The Lobby");
        base.OnJoinedLobby();
        InitializeRoom(NetworkManager.Instance.PlayerName);
       //RoomUI.SetActive(true);
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to Server");
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
       
    }

    public override void OnJoinedRoom(){
        //PlayerNumInRoom = PhotonNetwork.CountOfPlayers;
        //PlayerNumInRoom++;
        NetworkManager.Instance.PlayerName = "Player"+ PlayerNumInRoom.ToString();
        Debug.Log($"PlayerName: {NetworkManager.Instance.PlayerName}");
        Debug.Log($"Player Num In Room: {PlayerNumInRoom}");

        Debug.Log("Joined a Room");
        base.OnJoinedRoom();

        Debug.Log(NetworkManager.Instance.PlayerName+" Joined");
        //if(NetworkManager.Instance.PlayerName == "VRNetworkPlayer(1)")
        //{
        //    spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, new Vector3(0, 0.5f, -1.6f), Quaternion.Euler(0, 0, 0));
        //}
        //else if(NetworkManager.Instance.PlayerName == "VRNetworkPlayer(2)"){
        //    spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, new Vector3(0, 0.5f, 1.5f), Quaternion.Euler(0, 180, 0));
        //}
        //else{
        //    spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, new Vector3(0, 0, 1), Quaternion.Euler(0, 180, 0));

        //}
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
}

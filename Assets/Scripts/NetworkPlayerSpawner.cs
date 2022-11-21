using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;
    public static NetworkPlayerSpawner Instance;

    //   private void Awake()
    // {
    //     var objs = FindObjectsOfType<NetworkPlayerSpawner>();
    //     if(objs.Length == 1)
    //     {
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    void Start()
    {
        Instance = this;
        

    }
    private void Update()
    {
        
    }

    public override void OnJoinedRoom(){
        base.OnJoinedRoom();
        //NetworkManager.Instance.PlayerNum++;
        //print("Player Number: " + NetworkManager.Instance.PlayerNum + " Player is in this room");
        Debug.Log(NetworkManager.Instance.PlayerName+" Joined");
        if(NetworkManager.Instance.PlayerName == "VRNetworkPlayer(1)")
        {
            spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, transform.position, transform.rotation);
        }
        else if(NetworkManager.Instance.PlayerName == "VRNetworkPlayer(2)"){
            spawnedPlayerPrefab = PhotonNetwork.Instantiate(NetworkManager.Instance.PlayerName, new Vector3(1, 0, 1), Quaternion.Euler(0, 180, 0));
        }
        else{
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("NetWorkPlayer", transform.position, transform.rotation);

        }

        // if(PhotonNetwork.PlayerList.Length == 1)
        // {
        //     print("VRNetworkPlayer(1) is on");
        //     spawnedPlayerPrefab = PhotonNetwork.Instantiate("VRNetworkPlayer(2)", transform.position, transform.rotation);
        // }
        // if (PhotonNetwork.PlayerList.Length == 2)
        // {
        //     print("VRNetworkPlayer(2) is on"); 
        //     spawnedPlayerPrefab = PhotonNetwork.Instantiate("VRNetworkPlayer(1)", new Vector3(0, 0, 1), Quaternion.Euler(0, 180, 0));
        // }
        //print((PlayerNum+1) + " Player is in this room");
        //if (PlayerNum == 1)
        //{

        //    this.transform.Find("Head").transform.Find("Head_Sphere").GetComponent<MeshRenderer>().material = Player_mat[1];
        //    this.transform.position = new Vector3(0, 0, 1);
        //    this.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}

        //PhotonNetwork.LoadLevel("VRMultiHand");
    }

    public override void OnLeftRoom(){
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);
    }
}

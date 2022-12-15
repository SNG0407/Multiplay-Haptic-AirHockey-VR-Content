using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIManager : MonoBehaviour
{
    private PhotonView photonView;
    // Start is called before the first frame update
    public GameObject Paddle1;
    public GameObject Paddle2;
    public GameObject puck;

    public Transform Paddle1_Pos;
    public Transform Paddle2_Pos;
    public Transform puck_Pos;
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        Paddle1_Pos.position = Paddle1.transform.position;
        Paddle2_Pos.position = Paddle2.transform.position;
        puck_Pos.position = puck.transform.position;
    }

    public void resetPositions()
    {
        if (photonView.IsMine)
        {
            Paddle1.transform.position = Paddle1_Pos.position;
            Paddle1.transform.position = Paddle2_Pos.position;
            Paddle1.transform.position = puck_Pos.position;
        }
        else
        {
            Debug.Log("You're not a master. Can't reset");
        }
    }

}

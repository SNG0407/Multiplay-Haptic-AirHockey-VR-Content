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

    private Vector3 Paddle1_Pos;
    private Vector3 Paddle2_Pos;
    private Vector3 puck_Pos;
    void Start()
    {
        photonView = GetComponent<PhotonView>();

        Paddle1_Pos = Paddle1.transform.position;
        Paddle2_Pos = Paddle2.transform.position;
        puck_Pos = puck.transform.position;
    }

    public void resetPositions()
    {
        if (photonView.IsMine)
        {
            Paddle1.transform.position = Paddle1_Pos;
            Paddle2.transform.position = Paddle2_Pos;
            puck.transform.position = puck_Pos;
        }
        else
        {
            Debug.Log("You're not a master. Can't reset");
        }
    }

}

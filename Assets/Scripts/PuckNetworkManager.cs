﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PuckNetworkManager : MonoBehaviour
{
    private PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.name == "Collision_Table1" && NetworkManager.Instance.PlayerName == "Player1")
        //{
        //    Debug.Log("Player1 owns the puck");
        //    ChangeOwnerShip();
        //}
        //if (collision.gameObject.name == "Collision_Table2" && NetworkManager.Instance.PlayerName == "Player2")
        //{
        //    Debug.Log("Player2 owns the puck");
        //    ChangeOwnerShip();
        //}
    }
    //private void OnCollisionStay(Collider other)
    //{
       
    //        if (other.gameObject.name == "Collision_Table1" && NetworkManager.Instance.PlayerName == "Player1")
    //        {
    //            Debug.Log("Player1 owns the puck");
    //            ChangeOwnerShip();
    //        }
    //        if (other.gameObject.name == "Collision_Table2" && NetworkManager.Instance.PlayerName == "Player2")
    //        {
    //            Debug.Log("Player2 owns the puck");
    //            ChangeOwnerShip();
    //        }

    //}
    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.name == "Grabber")
        //{
        //    if (NetworkManager.Instance.PlayerName == "Player1")
        //    {
        //        Debug.Log("Player1 owns the puck");
        //        ChangeOwnerShip();
        //    }
        //    if (NetworkManager.Instance.PlayerName == "Player2")
        //    {
        //        Debug.Log("Player2 owns the puck");
        //        ChangeOwnerShip();
        //    }

        //    if (other.gameObject.name == "Collision_Table1" && NetworkManager.Instance.PlayerName == "Player1")
        //    {
        //        Debug.Log("Player1 owns the puck");
        //        ChangeOwnerShip();
        //    }
        //    if (other.gameObject.name == "Collision_Table2" && NetworkManager.Instance.PlayerName == "Player2")
        //    {
        //        Debug.Log("Player2 owns the puck");
        //        ChangeOwnerShip();
        //    }
        //}
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.name== "Collision_Table1" && NetworkManager.Instance.PlayerName == "Player1")
    //    {
    //        Debug.Log("Player1 owns the puck");
    //        ChangeOwnerShip();
    //    }
    //    if (collision.gameObject.name == "Collision_Table2" && NetworkManager.Instance.PlayerName == "Player2")
    //    {
    //        Debug.Log("Player2 owns the puck");
    //        ChangeOwnerShip();
    //    }
    //}
    public void ChangeOwnerShip()
    {
        photonView.RequestOwnership();
        Debug.Log("Ownership's changed");
    }
}

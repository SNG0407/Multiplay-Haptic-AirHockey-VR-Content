﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
//using UnityEngine.XR.Interaction.Toolkit;

public class NetworkPlayer : MonoBehaviourPunCallbacks
{
    public string PlayerName;
    private int PlayerNum = 0;

    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform Grabber;

    //private PhotonView photonView;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    private Transform HapticGrabber;

    public Material[] Player_mat = new Material[2];

    bool IsrigExist = false;
    bool IsHapticExist = false;

    // Start is called before the first frame update
    void Start()
    {
        //PlayerNum = PhotonNetwork.CountOfPlayersInRooms;

        //if (PlayerNum >=1)
        //{
        //    print((PlayerNum + 1) + " Player in in this room");

        //    PlayerName = (PlayerNum + 1) + "번 플레이어";
        //    print("PlayerName : " + PlayerName);
        //    if (PlayerName == "2번 플레이어")
        //    {
        //        this.transform.Find("Head").transform.Find("Head_Sphere").GetComponent<MeshRenderer>().material = Player_mat[1];
        //        this.transform.position = new Vector3(0, 0, 1);
        //        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        //    }
        //}

        //PlayerNum = PhotonNetwork.CountOfPlayersInRooms;
        //PlayerName = PhotonNetwork.PlayerList[PlayerNum].ActorNumber+ "번 플레이어";
        ////PlayerNum = PhotonNetwork.PlayerList[0].ActorNumber;
        //print((PlayerNum+1) + " Player is in this room");
        //if (PlayerNum == 1)
        //{
            
        //    this.transform.Find("Head").transform.Find("Head_Sphere").GetComponent<MeshRenderer>().material = Player_mat[1];
        //    this.transform.position = new Vector3(0, 0, 1);
        //    this.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}

        //photonView = GetComponenet<photonView>();
        XROrigin rig = FindObjectOfType<XROrigin>();
        //XR Origin/Camera Offset/
        if(rig != null)
        {
            IsrigExist = true;
            headRig = rig.transform.Find("Camera Offset/Main Camera");
            leftHandRig = rig.transform.Find("Camera Offset/LeftHand Controller");
            rightHandRig = rig.transform.Find("Camera Offset/RightHand Controller");
        }

        //hatpic device
        GameObject haptic = GameObject.FindGameObjectWithTag("HapticDevice");
        if(haptic != null)
        {
            IsHapticExist = true;
            HapticGrabber = haptic.transform.Find("Grabber");
        }


        if (photonView.IsMine)
        {
            ////PlayerName = "Opponent";
            //this.transform.position = new Vector3(0, 0, 1);
            //this.transform.rotation = Quaternion.Euler(0, 180, 0);
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                //item.enabled = false;
            }
        }
        else
        {
            //this.transform.Find("Head_Sphere").GetComponent<MeshRenderer>().material = Player_mat[1];
            //PlayerName = "Mine";
        }
        //Debug.Log("Player Name : "+PlayerName);
        //Debug.Log("rig : "+rig);
        //Debug.Log("headRig : "+headRig);
        //Debug.Log("leftHandRig : "+leftHandRig);
        //Debug.Log("rightHandRig : "+rightHandRig);
        // Debug.Log(andr);

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (photonView.IsMine)
        {
            // head.gameObject.SetActive(false);
            // leftHand.gameObject.SetActive(false);
            // rightHand.gameObject.SetActive(false);
            if (IsrigExist == true)
            {
                MapPosition(head, headRig);
                MapPosition(leftHand, leftHandRig);
                MapPosition(rightHand, rightHandRig);

                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
                UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
            }
            if (IsHapticExist == true)
            {
                MapPosition(Grabber, HapticGrabber);
            }



            //Debug.Log("headRig : "+headRig.transform.position);
            //Debug.Log("leftHandRig : "+leftHandRig.transform.position);
            //Debug.Log("rightHandRig : "+rightHandRig.transform.position);
        }
    } 
    
     void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }


     void MapPosition(Transform target, Transform rigTransform)
    {
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position);
        //InputDevices.GetDeviceAtXRNode(node).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation);

        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}

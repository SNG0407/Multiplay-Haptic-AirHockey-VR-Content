using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using Unity.XR.CoreUtils;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable 
{
    private PhotonView photonview;
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        photonview.RequestOwnership();
        base.OnSelectEntering(interactor);
    }
}

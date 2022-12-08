using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HapticNetworkPlugin : HapticGrabber // HapticGrabber //HapticPlugin
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
    //private override void  

    public override void OnCollisionExit(Collision collisionInfo)
    {
        base.OnCollisionExit(collisionInfo);
    }
    public override void OnCollisionEnter(Collision collisionInfo)
    {
        collisionInfo.gameObject.GetPhotonView().RequestOwnership();
        base.OnCollisionEnter(collisionInfo);
        
    }
    //public override void grab()
    //{
    //    photonView.RequestOwnership();
    //    base.grab();
    //}

    //public override void release()
    //{
    //    base.release();
    //}
}

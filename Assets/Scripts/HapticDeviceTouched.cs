using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticDeviceTouched : MonoBehaviour
{
    GameObject CurrentObj;
    private void Start()
    {
        CurrentObj = this.gameObject;
    }
    void OnCollisionEnter(Collision col)
    {
        //if (CurrentObj.name == "Triangle" || CurrentObj.name == "Triangle1" || CurrentObj.name == "Triangle2" || CurrentObj.name == "Triangle3" || CurrentObj.name == "Triangle4" || CurrentObj.name == "Triangle5")
        //{
        //    Debug.Log("col: " + col.gameObject.name);
        //    Debug.Log("CurrentObj: " + CurrentObj.name);
        //}
        if (col.gameObject.name == "Grabber")
        {
            if (CurrentObj.name == "paddleAirhockey (1)" || CurrentObj.name == "paddleAirhockey (2)")
            {
                //Debug.Log("paddleAirhockey");
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("This rotation: "+gameObject.transform.rotation);
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.name == "Grabber")
        {
            if (CurrentObj.name == "paddleAirhockey (1)" || CurrentObj.name == "paddleAirhockey (2)" || CurrentObj.name == "paddleAirhockey")
            {
                //Debug.Log("paddleAirhockey");
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("This rotation: " + gameObject.transform.rotation);
            }
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Grabber")
        {
            if (CurrentObj.name == "paddleAirhockey (1)" || CurrentObj.name == "paddleAirhockey (2)" || CurrentObj.name == "paddleAirhockey")
            {
                //Debug.Log("paddleAirhockey");
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                //Debug.Log("This rotation: " + gameObject.transform.rotation);
            }
                //Debug.Log("This rotation: " + gameObject.transform.rotation);
        }
    }
}

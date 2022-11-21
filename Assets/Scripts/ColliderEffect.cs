using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEffect : MonoBehaviour
{
    //public GameObject m_Target;
    public GameObject m_Effect;
    int count = 0;

    private void OnCollisionEnter(Collision other) {
            print("Hand");

        if(other.gameObject.tag == "Player")
        {
            print("It hit something!!");
            GameObject obj = Instantiate(m_Effect, transform.position, transform.rotation);
            Destroy(obj, 1.5f);
        }if(other.gameObject.tag == "HandMesh")
        {
            print("Hand touched by ao obj!");
            GameObject obj = Instantiate(m_Effect, transform.position, transform.rotation);
            Destroy(obj, 1.5f);
        }
        if(this.gameObject.tag == "HandMesh"){
            print("It hit Hand!!");
            GameObject obj = Instantiate(m_Effect, transform.position, transform.rotation);
            Destroy(obj, 1.5f);

        }
    }

}

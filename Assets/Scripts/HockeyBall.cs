using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HockeyBall : MonoBehaviour
{
    public Text score1;
    public Text score2;
    private int getScore1 = 0;
    private int getScore2 = 0;
    // Start is called before the first frame update
    void Start()
    {
       // score1 = GameObject.Find("Score1").GetComponent<Text>();
        //score2 = GameObject.Find("Score2").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //SetScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject ball;
        if (collision.collider.gameObject.CompareTag("Goal"))
        {
            getScore1++;
            Debug.Log("Goal");
            Destroy(gameObject);
            ball = Instantiate(gameObject);
            ball.transform.position = new Vector3(0, 11, -10);
        }
        //Tag를 골대별로 만들어서 점수 올리면 될 것 같습니다.
        else if (collision.collider.gameObject.CompareTag("Goal2"))
        {
            getScore2++;
            Debug.Log("Goal");
            Destroy(gameObject);
            ball = Instantiate(gameObject);
            ball.transform.position = new Vector3(0, 11, -10);
        }

    }
   
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("TableCol"))
        {
            //ball = Instantiate(gameObject);
            this.gameObject.transform.position = new Vector3(-0.353f, -0.353f, -1.6f);
        }
    }

    void SetScoreText()
    {
        score1.text = getScore1.ToString();
        score2.text = getScore2.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class HockeyBall : MonoBehaviour
{
    private PhotonView photonView;

    public Text Player1_score1;
    public Text Player1_score2;
    public Text Player2_score1;
    public Text Player2_score2;

    private int getScore1 = 0;
    private int getScore2 = 0;

    private GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        // score1 = GameObject.Find("Score1").GetComponent<Text>();
        //score2 = GameObject.Find("Score2").GetComponent<Text>();
        ball = gameObject;
        photonView = GetComponent<PhotonView>();

    }

    // Update is called once per frame
    void Update()
    {
        //SetScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(photonView.IsMine)
        {
            if (other.gameObject.CompareTag("Goal"))
            {
                getScore1++;
                Debug.Log("Goal 1");
                //Destroy(gameObject);
                //ball = Instantiate(gameObject);
                ball.transform.position = new Vector3(-0.04f, 1.06f, 2.2f); //Player2's ball
                ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
            //Tag를 골대별로 만들어서 점수 올리면 될 것 같습니다.
            else if (other.gameObject.CompareTag("Goal2"))
            {
                getScore2++;
                Debug.Log("Goal 2");
                ball.transform.position = new Vector3(-0.04f, 1.06f, -0.5f);
                ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            }
            SetScoreText();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (photonView.IsMine)
        {
            if (other.gameObject.CompareTag("TableCol"))
            {
                //ball = Instantiate(gameObject);
                this.gameObject.transform.position = new Vector3(-0.08f, 1.06f, 0.86f); //가운데로
            }
        }
            
    }

    void SetScoreText()
    {
        Player1_score1.text = getScore1.ToString();
        Player2_score1.text = getScore1.ToString();
        Player1_score2.text = getScore2.ToString();
        Player2_score2.text = getScore2.ToString();
    }

    public void ResetBtn()
    {
        if (photonView.IsMine)
        {
            ball.gameObject.GetComponent<PuckNetworkManager>().ChangeOwnerShip();
            this.gameObject.transform.position = new Vector3(-0.08f, 1.06f, 0.86f);
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

            getScore1 = 0;
            getScore2 = 0;
            SetScoreText();
        }
        
    }
}
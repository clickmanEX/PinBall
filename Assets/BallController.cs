using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    public Score score;     //得点を表示するためのスクリプト「Score」を参照
    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;

    // Use this for initialization
    void Start()
    {

        this.gameoverText = GameObject.Find("GameOverText");

    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }

    //スコアを加算するための計算
    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "SmallStarTag")
        {
            score.GetComponent<Score>().scorePt += 5;
        }
        else if (target.gameObject.tag == "LargeStarTag")
        {
            score.GetComponent<Score>().scorePt += 15;
        }
        else if (target.gameObject.tag == "SmallCloudTag")
        {
            score.GetComponent<Score>().scorePt += 10;
        }
        else if (target.gameObject.tag == "LargeCloudTag")
        {
            score.GetComponent<Score>().scorePt += 20;
        }

    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private GameObject scoreText;
    public int scorePt = 0;   

    // Use this for initialization
    void Start () {
        this.scoreText = GameObject.Find("ScoreText");
    }
	
	// Update is called once per frame
	void Update () {

        this.scoreText.GetComponent<Text>().text = "Score " + scorePt.ToString();
    }
}

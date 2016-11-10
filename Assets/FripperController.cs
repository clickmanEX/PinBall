using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {

    private HingeJoint myHingeJoynt;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    

	// Use this for initialization
	void Start () {
        this.myHingeJoynt = GetComponent<HingeJoint>();

        SetAngle(this.defaultAngle);
	
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            SetAngle(this.defaultAngle);
        }

        ///タッチ座標をスクリーン座標からワールド座標に変換し、x座標で画面を左右2分割にしてフリッパーを制御
        foreach (Touch touch in Input.touches)
        {
            ///タッチ座標がx,y座標しかないのでz座標を追加し、ワールド座標に変換
            Vector3 pos = touch.position;
            pos.z = 100f;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);


            if (touch.phase == TouchPhase.Began && worldPos.x <= 0 && tag == "LeftFripperTag")
            {
                SetAngle(this.flickAngle);
                Debug.Log(worldPos.x);
            }

            if (touch.phase == TouchPhase.Began && worldPos.x > 0 && tag == "RightFripperTag")
            {
                SetAngle(this.flickAngle);
                Debug.Log(worldPos.x);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                SetAngle(this.defaultAngle);
            }

        }
    }


    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoynt.spring = jointSpr;
    }
}

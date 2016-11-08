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
	void Update () {

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
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoynt.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoynt.spring = jointSpr;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour {



    private Animator animator;
    private Rotate ropeRotator;
    private sc_StopRopePoint ropeFinishPoint;
    private int previousHighScore ;
    private sc_playerT playerScript;
    // Use this for initialization
    void Start () {
        GameObject playerModel = GameObject.Find("T-Jump_Model-20171201 (1)");
        animator = playerModel.GetComponent<Animator>();
        playerScript = playerModel.GetComponent<sc_playerT>();
        previousHighScore = playerScript.totalHighScore;

        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>();
        ropeFinishPoint = GameObject.Find("RopeStopPoint").GetComponent<sc_StopRopePoint>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.tag == "Rope")
        {
            //GetComponent<>
            animator.SetBool("Colided", true);
            ropeRotator.toStop = true;
            if (ropeFinishPoint.currentScore > previousHighScore)
            {
                animator.SetBool("HighScore", true);
                playerScript.totalHighScore = ropeFinishPoint.currentScore;
            }
        }

    }
}

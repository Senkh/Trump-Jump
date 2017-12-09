using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FeetCollider : MonoBehaviour {



    private Animator animator;
    private Rotate ropeRotator;
    private sc_StopRopePoint ropeFinishPoint;
    private int previousHighScore ;
    private sc_playerT playerScript;
    public Text HighScore;
    public Text congrats;

    // Use this for initialization
    void Start () {
        GameObject playerModel = GameObject.Find("T-Jump_Model-20171201 (1)");
        animator = playerModel.GetComponent<Animator>();
        playerScript = playerModel.GetComponent<sc_playerT>();
        previousHighScore = playerScript.totalHighScore;

        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>();
        ropeFinishPoint = GameObject.Find("RopeStopPoint").GetComponent<sc_StopRopePoint>();
        HighScore = GameObject.Find("HighScore").GetComponent<Text>();
        congrats = GameObject.Find("Congrats").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private string newScore(string text, int score)
    {
        return String.Concat(text.Remove(text.Length - score.ToString().Length), score.ToString());

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
                HighScore.text = newScore(HighScore.text, ropeFinishPoint.currentScore);
                congrats.enabled = true;
            }
        }

    }
}

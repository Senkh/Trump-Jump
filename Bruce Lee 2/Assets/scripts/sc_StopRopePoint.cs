using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class sc_StopRopePoint : MonoBehaviour {


    private Rotate ropeRotator;
    public int currentScore = 0;
    public Text Score;

    // Use this for initialization
    void Start () {
        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>();
        Score = GameObject.Find("Score").GetComponent<Text>();

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

        if (hit.gameObject.tag == "Rope" && ropeRotator.toStop)
        {
            ropeRotator.StopRotation();
            ropeRotator.toStop = false;
        }
        else if (hit.gameObject.tag == "Rope" && !ropeRotator.toStop)
        {
            currentScore++;
            Score.text = newScore(Score.text, currentScore);
            
        }

    }
}

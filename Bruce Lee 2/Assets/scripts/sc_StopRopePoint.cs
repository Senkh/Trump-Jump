using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_StopRopePoint : MonoBehaviour {


    private Rotate ropeRotator;
    public int currentScore = 0;

    // Use this for initialization
    void Start () {
        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>();
    }
	
	// Update is called once per frame
	void Update () {
		
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
            
        }

    }
}

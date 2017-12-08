using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour {



    private Animator animator;
    private Rotate ropeRotator;
    // Use this for initialization
    void Start () {
        
        animator = GameObject.Find("T-Jump_Model-20171201 (1)").GetComponent<Animator>();
        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>(); 
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
            //ropeRotator.StopRotation();
            //Invoke("ColisionOf", 5.0f);
        }

    }
}

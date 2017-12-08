using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollider : MonoBehaviour {



    private Animator animator;
    // Use this for initialization
    void Start () {
        
        animator = GameObject.Find("T-Jump_Model-20171201 (1)").GetComponent<Animator>();
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
            //Invoke("ColisionOf", 5.0f);
        }

    }
}

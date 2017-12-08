using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_playerT : MonoBehaviour {


    private Rigidbody rb;
    private bool grounded;
    public float Jumpforce = 5.0f;
    private Animator animator;

    int jumpHash = Animator.StringToHash("New State");

    // Use this for initialization
    void Start () {

        rb =   GetComponent<Rigidbody>();
        grounded = true;
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		

	}

    private void FixedUpdate()
    {
        //animator.SetBool("Jump", false);
        //animator.SetBool("Colided", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(transform.up * force, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0, Jumpforce, 0), ForceMode.Impulse);
            animator.SetInteger("jumpInt", 1);
            grounded = false;
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //rb.AddForce(transform.up * force, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0, Jumpforce, 0), ForceMode.Impulse);
            animator.SetBool("Colided", true);
            grounded = false;

        }
    }


    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            grounded = true;
        }

        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_playerT : MonoBehaviour {


    //private Rigidbody rb;
    //private bool grounded;
    //public float Jumpforce = 5.0f;
    private Animator animator;
    public int totalHighScore;
    public Text congrats;
    public int WhichJump;

    
    int jumpHash = Animator.StringToHash("New State");

    // Use this for initialization
    void Start () {

        //rb =   GetComponent<Rigidbody>();
        //grounded = true;
        animator = GetComponent<Animator>();
        totalHighScore = 0;
        Random.InitState(GetInstanceID());
        congrats = GameObject.Find("Congrats").GetComponent<Text>();
        WhichJump = 3;

    }
	


    private void Update()
    {
        //animator.SetBool("Jump", false);
        //animator.SetBool("Colided", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(transform.up * force, ForceMode.Impulse);
            if (animator.GetBool("HighScore"))
            {
                animator.SetBool("HighScore", false);
                animator.SetBool("goIdle", true);
                congrats.enabled = false;
            }
            else
                if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
            {

                //animator.SetInteger("jumpInt", Random.Range(1, 4));
                animator.SetInteger("jumpInt", WhichJump);
            }
            
            //grounded = false;
            
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            //rb.AddForce(transform.up * force, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0, Jumpforce, 0), ForceMode.Impulse);
            animator.SetBool("Colided", true);
            //grounded = false;

        }
    }




}

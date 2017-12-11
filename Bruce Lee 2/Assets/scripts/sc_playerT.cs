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
    //public int TestWhichJump;
    private sc_audioController audio_controller;

    //jump 3 and 2 are the same
    private GameObject _jumpPoint3;
    private GameObject _jumpPoint1;

    private int _nextJump;




    int jumpHash = Animator.StringToHash("New State");

    // Use this for initialization
    void Start () {

        //rb =   GetComponent<Rigidbody>();
        //grounded = true;
        animator = GetComponent<Animator>();
        totalHighScore = 0;
        Random.InitState(GetInstanceID());
        congrats = GameObject.Find("Congrats").GetComponent<Text>();
        _jumpPoint3 = GameObject.Find("JumpPoint3");
        _jumpPoint1 = GameObject.Find("JumpPoint1");

        audio_controller = GameObject.Find("AudioController").GetComponent<sc_audioController>();

        _nextJump = 3;

    }
	


    private void Update()
    {
        //animator.SetBool("Jump", false);
        //animator.SetBool("Colided", false);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Gets out of celebration
            if (animator.GetBool("HighScore"))
            {
                animator.SetBool("HighScore", false);
                animator.SetBool("goIdle", true);
                congrats.enabled = false;
            }
            else
            {       //if not jumping
                    if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump"))
                    {

                        
                        audio_controller.PlayJumpAudio(_nextJump);
                        animator.SetInteger("jumpInt", _nextJump);

                        _nextJump = Random.Range(1, 4);
                        SetNextJump(_nextJump);

                }
            }
            
            //grounded = false;
            
        }
        //Drops player imediatly, mostly for testing and fun
        if (Input.GetKeyDown(KeyCode.C))
        {
            //rb.AddForce(transform.up * force, ForceMode.Impulse);
            //rb.AddForce(new Vector3(0, Jumpforce, 0), ForceMode.Impulse);
            animator.SetBool("Colided", true);

            int whichJump = Random.Range(1, 4);
            audio_controller.PlayJumpAudio(whichJump);
            //grounded = false;

        }
    }

    private void SetNextJump(int jump)
    {
        if (jump == 1)
        {
            _jumpPoint1.SetActive(true);
            _jumpPoint3.SetActive(false);
        }
        else
        {
            _jumpPoint1.SetActive(false);
            _jumpPoint3.SetActive(true);
        }
    }




}

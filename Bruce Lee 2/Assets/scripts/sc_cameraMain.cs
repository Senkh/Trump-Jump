using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cameraMain : MonoBehaviour {



    private Camera mainCam;
    public Camera secCam;
    public Camera UICamera;


    // Use this for initialization
    void Start () {

        mainCam = Camera.main;
        //secCam = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();
       // UICamera = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();

        mainCam.enabled = false;
        secCam.enabled = true;
        UICamera.enabled = false;
    }

    public void EnableMainCamera()
    {
        mainCam.enabled = true;
        secCam.enabled = false;
        UICamera.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCam.enabled = true;
            secCam.enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCam.enabled = false;
            secCam.enabled = true;

        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            UICamera.enabled = !UICamera.enabled;
        }
    }
}

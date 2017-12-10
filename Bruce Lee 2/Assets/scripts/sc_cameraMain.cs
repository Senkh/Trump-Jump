using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_cameraMain : MonoBehaviour {



    private Camera mainCam;
    private Camera cutCam;
    private Camera UICamera;


    // Use this for initialization
    void Start () {

        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        cutCam = GameObject.Find("CameraCut1").GetComponent<Camera>();
        UICamera = GameObject.Find("UICamera").GetComponent<Camera>();

        //cutCam = UICamera = mainCam;

        goToMainCam();
    }


    public void goToCutScenecam()
    {
        mainCam.enabled = false;
        cutCam.enabled = true;
        UICamera.enabled = false;
        UICamera.enabled = true;

    }

    public void goToMainCam()
    {
        mainCam.enabled = true;
        cutCam.enabled = false;
        UICamera.enabled = false;
        UICamera.enabled = true;

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            goToMainCam();

        }
        if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            goToCutScenecam();

        }
        if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            UICamera.enabled = !UICamera.enabled;
        }
    }
}

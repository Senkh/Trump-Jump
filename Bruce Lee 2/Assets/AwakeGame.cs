using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeGame : MonoBehaviour {



    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject.Find("Intro").GetComponent<TextMesh>().text = "Make America Great Again";
            GameObject.Find("BaseCutscene").GetComponent<QuickCutsceneController>().ActivateCutscene();
            
        }
    }

}

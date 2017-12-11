using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class FeetCollider : MonoBehaviour {



    private Animator animator;
    private Rotate ropeRotator;
    private sc_StopRopePoint ropeFinishPoint;
    private sc_audioController _audioController;
    private int previousHighScore ;
    private sc_playerT playerScript;
    private sc_cameraMain _cameraControl;
    private Camera _originalCutsceneCamera;

    public Text HighScore;
    public Text Score;
    public Text congrats;

    private QuickCutsceneController _cutSceneController;

    // Use this for initialization
    void Start () {
        GameObject playerModel = GameObject.Find("T-Jump_Model-20171201 (1)");
        animator = playerModel.GetComponent<Animator>();
        playerScript = playerModel.GetComponent<sc_playerT>();
        previousHighScore = playerScript.totalHighScore;

        ropeRotator = GameObject.Find("RopeGravityCenter").GetComponent<Rotate>();
        ropeFinishPoint = GameObject.Find("RopeStopPoint").GetComponent<sc_StopRopePoint>();
        _audioController = GameObject.Find("AudioController").GetComponent<sc_audioController>();
        _cutSceneController = GameObject.Find("Cutscene").GetComponent<QuickCutsceneController>();
        _cameraControl = GameObject.Find("Main Camera").GetComponent<sc_cameraMain>();

        HighScore = GameObject.Find("HighScore").GetComponent<Text>();
        Score = GameObject.Find("Score").GetComponent<Text>();
        congrats = GameObject.Find("Congrats").GetComponent<Text>();

        _originalCutsceneCamera.CopyFrom(_cutSceneController.mainCutsceneCam);

        //initiate rand
        UnityEngine.Random.InitState(GetInstanceID());

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private string newScore(string text, int score)
    {
        return String.Concat(text.Remove(text.Length - score.ToString().Length), score.ToString());

    }

    private void StopCutScene()
    {
        //_cutSceneController.EndCutscene();
        _cameraControl.goToMainCam();
        _cutSceneController.mainCutsceneCam.CopyFrom(_originalCutsceneCamera);
        
    }

    private void StartCutScene()
    {
        //Go to CutScene
        _cutSceneController.ActivateCutscene();
        _cameraControl.goToCutScenecam();
        Invoke("StopCutScene", 6);
    }

    private void DoHighScore()
    {

        int whichScore = UnityEngine.Random.Range(1, 4);
        //High Score Sequence
        animator.SetBool("HighScore", true);

        congrats.enabled = true;

        //Open Cutscene
        StartCutScene();

        //when Highscore play Highscore sound
        _audioController.PlayHighScoreAudio(whichScore);
        ropeFinishPoint.currentScore = 0;

        Score.text = newScore(Score.text, ropeFinishPoint.currentScore);
    }

    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.tag == "Rope")
        {
            //Drop Animation
            animator.SetBool("Colided", true);
            ropeRotator.toStop = true;


            //Stops what character is saying
            if (_audioController.isAnythingPlayingButMusic())
                _audioController.StopAllButMusic();

            if (ropeFinishPoint.currentScore > previousHighScore)
            {
                playerScript.totalHighScore = ropeFinishPoint.currentScore;
                HighScore.text = newScore(HighScore.text, ropeFinishPoint.currentScore);
                previousHighScore = ropeFinishPoint.currentScore;


                Invoke("DoHighScore", 9.2f);
            }
            else //if not highscore
            {
                int whichFall = UnityEngine.Random.Range(1, 4);
                _audioController.PlayFallAudio(whichFall);
            }
        }

    }
}

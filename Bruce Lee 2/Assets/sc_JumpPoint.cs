
using UnityEngine;
using UnityEngine.UI;

public class sc_JumpPoint : MonoBehaviour {

    private Text _jumpText;
	// Use this for initialization
	void Start () {

        _jumpText = GameObject.Find("Jump").GetComponent<Text>();
    }
	

    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.tag == "Rope" )
        {
            _jumpText.enabled = true;
            Invoke("DisableJumpText", 0.2f);
            //ropeRotator.toStop = false;
        }

    }

    private void DisableJumpText()
    {
        _jumpText.enabled = false;
    }
}

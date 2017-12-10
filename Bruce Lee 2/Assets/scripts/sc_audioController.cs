using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_audioController : MonoBehaviour {


    public AudioClip Jump1;
    public AudioClip Jump2;
    public AudioClip Jump3;
    public AudioClip Idle1;
    public AudioClip Idle2;
    public AudioClip Idle3;
    public AudioClip Fail1;
    public AudioClip Fail2;
    public AudioClip Fail3;
    public AudioClip HScore1;
    public AudioClip HScore2;
    public AudioClip HScore3;
    public AudioClip Music;


    //TODO: Add only 1 source for same config of audio
    private AudioSource _Jump1;
    private AudioSource _Jump2;
    private AudioSource _Jump3;
    private AudioSource _Idle1;
    private AudioSource _Idle2;
    private AudioSource _Idle3;
    private AudioSource _Fail1;
    private AudioSource _Fail2;
    private AudioSource _Fail3;
    private AudioSource _HScore1;
    private AudioSource _HScore2;
    private AudioSource _HScore3;
    [HideInInspector]
    public AudioSource _Music;




    // Use this for initialization
    void Awake () {

        // add the necessary AudioSources:
        _Jump1 = AddAudio(Jump1, false, false, 0.2f);
        _Jump2 = AddAudio(Jump2, false, false, 0.2f);
        _Jump3 = AddAudio(Jump3, false, false, 0.2f);
        _Idle1 = AddAudio(Idle1, false, false, 0.2f);
        _Idle2 = AddAudio(Idle2, false, false, 0.2f);
        _Idle3 = AddAudio(Idle3, false, false, 0.2f);
        _Fail1 = AddAudio(Fail1, false, false, 0.2f);
        _Fail2 = AddAudio(Fail2, false, false, 0.2f);
        _Fail3 = AddAudio(Fail3, false, false, 0.2f);
        _HScore1 = AddAudio(HScore1, false, false, 0.2f);
        _HScore2 = AddAudio(HScore2, false, false, 0.2f);
        _HScore3 = AddAudio(HScore3, false, false, 0.2f);
        _Music = AddAudio(Music, true, true, 0.07f);

        _Music.Play();

    }


    public bool isAnythingPlaying()
    {

        bool isPlaying = _Fail1.isPlaying || _Fail2.isPlaying || _Fail3.isPlaying || _HScore1.isPlaying || _HScore2.isPlaying || _HScore3.isPlaying;
        isPlaying = isPlaying || _Idle1.isPlaying || _Idle2.isPlaying || _Idle3.isPlaying || _Jump1.isPlaying || _Jump2.isPlaying || _Jump3.isPlaying;
        isPlaying = isPlaying || _Music.isPlaying;

        return isPlaying;
    }

    public bool isAnythingPlayingButMusic()
    {

        bool isPlaying = _Fail1.isPlaying || _Fail2.isPlaying || _Fail3.isPlaying || _HScore1.isPlaying || _HScore2.isPlaying || _HScore3.isPlaying;
        isPlaying = isPlaying || _Idle1.isPlaying || _Idle2.isPlaying || _Idle3.isPlaying || _Jump1.isPlaying || _Jump2.isPlaying || _Jump3.isPlaying;
        //isPlaying = isPlaying && _Music.isPlaying;

        return isPlaying;
    }

    public void StopAll()
    {

        _Fail1.Stop(); _Fail2.Stop(); _Fail3.Stop(); _HScore1.Stop(); _HScore2.Stop(); _HScore3.Stop(); _Idle1.Stop(); _Idle2.Stop();
        _Idle3.Stop(); _Jump1.Stop(); _Jump2.Stop(); _Jump3.Stop();
        _Music.Stop();

    }
    public void StopAllButMusic()
    {

        _Fail1.Stop(); _Fail2.Stop(); _Fail3.Stop(); _HScore1.Stop(); _HScore2.Stop(); _HScore3.Stop(); _Idle1.Stop(); _Idle2.Stop();
        _Idle3.Stop(); _Jump1.Stop(); _Jump2.Stop(); _Jump3.Stop();

    }

    public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
    {

        AudioSource newAudio = gameObject.AddComponent<AudioSource>();

        newAudio.clip = clip;
        newAudio.loop = loop;
        newAudio.playOnAwake = playAwake;
        newAudio.volume = vol;

        return newAudio;

    }


    public void PlayJumpAudio(int jumpNumber)
    {
        if (!isAnythingPlayingButMusic())
        {
            switch (jumpNumber)
            {
                case 1:
                    _Jump1.Play();
                    break;
                case 2:
                    _Jump2.Play();
                    break;
                case 3:
                    _Jump3.Play();
                    break;
            }
        }
    }

    public void PlayHighScoreAudio(int highNumber)
    {
        if (!isAnythingPlayingButMusic())
        {
            switch (highNumber)
            {
                case 1:
                    _HScore1.Play();
                    break;
                case 2:
                    _HScore2.Play();
                    break;
                case 3:
                    _HScore3.Play();
                    break;
            }
        }
    }

    public void PlayFallAudio(int fallNumber)
    {
        if (!isAnythingPlayingButMusic())
        {
            switch (fallNumber)
            {
                case 1:
                    _Fail1.Play();
                    break;
                case 2:
                    _Fail2.Play();
                    break;
                case 3:
                    _Fail3.Play();
                    break;
            }
        }
    }

    public void PlayIdleAudio(int idleNumber)
    {
        if (!isAnythingPlayingButMusic())
        {
            switch (idleNumber)
            {
                case 1:
                    _Idle1.Play();
                    break;
                case 2:
                    _Idle2.Play();
                    break;
                case 3:
                    _Idle3.Play();
                    break;
            }
        }
    }
}

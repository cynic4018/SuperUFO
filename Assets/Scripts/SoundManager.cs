using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundSound;
    public AudioSource jumpSound;
    public AudioSource dieSound;
    public AudioSource scoreUpSound;
    public AudioSource buttonClickSound;
    public AudioMixer mixer;

    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
        mixer.SetFloat("BG", PlayerPrefs.GetFloat("BG"));
        mixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFX"));
        backgroundSound.Play();
    }

    public void DieSoundActive()
    {
        dieSound.Play();
    }

    public void JumpSoundActive()
    {
        jumpSound.Play();
    }

    public void ScoreUpSoundActive()
    {
        scoreUpSound.Play();
    }

    public void ButtonClickSoundActive()
    {
        buttonClickSound.Play();
    }
}

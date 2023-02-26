using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip step;
    public AudioClip jump;
    public AudioClip longFall;

    private void playAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void stepAudio()
    {
        playAudio(step);
    }

    public void jumpAudio()
    {
        playAudio(jump);
    }

    public void longFallAudio()
    {
        playAudio(longFall);
    }
}

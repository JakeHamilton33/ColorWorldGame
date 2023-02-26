using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public void step1Audio()
    {
        FindObjectOfType<AudioManager>().play("Step1");
    }

    public void step2Audio()
    {
        FindObjectOfType<AudioManager>().play("Step2");
    }

    public void jump1Audio()
    {
        FindObjectOfType<AudioManager>().play("Jump1");
    }
    public void jump2Audio()
    {
        FindObjectOfType<AudioManager>().play("Jump2");
    }

    public void longFallAudio()
    {
        FindObjectOfType<AudioManager>().play("LongFall");
    }
}

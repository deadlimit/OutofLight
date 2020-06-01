using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSounds : MonoBehaviour
{
    public AudioClip[] growls = new AudioClip[3];
    public IntVariable darkSteps;
    private AudioSource audio;


    private void Awake()
    {
        audio = GameObject.FindWithTag("Audio").GetComponent<AudioSource>();
    }

    public void PlayGrowl()
    {
        if (darkSteps.GetValue() >= 7)
        {
            audio.clip = growls[2];
            audio.PlayOneShot(audio.clip);
        }
    }

}

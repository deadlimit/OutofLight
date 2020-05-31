using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public FloatVariable volume;
    public AudioSource audio;

    private void Awake()
    {
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();
    }

    private void Update()
    {
        audio.volume = volume.GetValue();
    }
}

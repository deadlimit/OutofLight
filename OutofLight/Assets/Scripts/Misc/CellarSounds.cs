using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellarSounds : MonoBehaviour
{
    public AudioSource cellarAudio;
    public AudioClip gertrude, distantGrowl;

    private void Awake()
    {
        cellarAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cellarAudio.clip = distantGrowl;
            cellarAudio.Play();
        }
    }

    public void GertrudeSound()
    {
        cellarAudio.clip = gertrude;
        cellarAudio.Play();
    }

}

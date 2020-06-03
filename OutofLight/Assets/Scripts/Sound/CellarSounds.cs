using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellarSounds : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip gertrude, distantGrowl;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio.clip = distantGrowl;
            audio.Play();
        }
    }

    public void PlayGertrude()
    {
        audio.clip = gertrude;
        audio.Play();
    }


}

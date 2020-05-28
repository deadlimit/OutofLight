using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveSFX : MonoBehaviour {

	public AudioSource audio;

	public void Awake() {
		audio = GetComponent<AudioSource>();
	}
	
	public void Play(AudioClip clip) {
		audio.PlayOneShot(clip);
	}

}

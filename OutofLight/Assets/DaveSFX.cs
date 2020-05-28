using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveSFX : MonoBehaviour {

	public AudioSource audio;
	public SoundDictionary soundLibrary;

	private Material currentMaterial;
	
	public void Awake() {
		audio = GetComponent<AudioSource>();
		CheckWalkingMaterial();
	}
	
	public void Play() {
		audio.PlayOneShot(soundLibrary.GetAudioClip(currentMaterial));
	}

	public void CheckWalkingMaterial() {
		var ray = new Ray(transform.position, Vector3.down * 2);
		bool obj = Physics.Raycast(ray, out var hit);

		if (!obj) return;
		Debug.Log(hit.transform.gameObject);
		currentMaterial = hit.transform.gameObject.GetComponent<MeshRenderer>().material;
	}
}

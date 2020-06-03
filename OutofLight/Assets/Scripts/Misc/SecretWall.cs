using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretWall : MonoBehaviour, ILever {

	public Transform wallOne;

	public float newY;
	public float backY;

	public AudioSource audio;
	
	public void RotateWalls() {
		wallOne.LeanRotateY(newY, 2);
	}

	public void RotateBack() {
		if(audio != null)
			audio.Play();
		wallOne.LeanRotateY(backY, 2);
	}

	public void Method() {
		if(audio != null)
			audio.Play();
		RotateWalls();
	}
}

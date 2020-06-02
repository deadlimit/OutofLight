using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretWindow : MonoBehaviour {

	public Material material;

	private void Awake() {
		material.SetColor("_BaseColor", Color.white);
	}
	
	public void Reveal() {
		StartCoroutine(LerpColor(Color.black));
	}

	public void Hide() {
		StartCoroutine(LerpColor(Color.white));
	}
	
	private IEnumerator LerpColor(Color targetColor) {
		float start = 0;
		float end = 2;
		while (start < end) {
			var newColor = Color.Lerp(material.GetColor("_BaseColor"), targetColor, Time.deltaTime);
			material.SetColor("_BaseColor", newColor);
			start += Time.deltaTime;
			yield return null;
		}
		
		material.SetColor("_BaseColor", targetColor);
	}
	
}

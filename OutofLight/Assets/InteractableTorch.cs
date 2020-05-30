using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class InteractableTorch : MonoBehaviour, IInteractable {

	public ParticleSystem[] torchEffects = new ParticleSystem[5];

	public int sequenceNumber;
	
	private IEnumerator ChangeLight(int value, int index) {
		var main = torchEffects[index].main;
		while (main.maxParticles != value) {
			main.maxParticles = (int)Mathf.Lerp(main.maxParticles, value, 200 * Time.deltaTime);
			yield return null;
		}
	}
	
	public void ChangeMaxParticles(int value) {
		for (var i = 0; i < torchEffects.Length; i++) {
			StartCoroutine(ChangeLight(value, i));
		}
	}

	public void Use() {
		ChangeMaxParticles(1000);
	}

	public string GetPrompt() {
		return "Light torch";
	}

	public Button CustomSprite() {
		return null;
	}
}
	

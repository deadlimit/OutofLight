using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class InteractableTorch : MonoBehaviour, IInteractable {

	public ParticleSystem[] torchEffects = new ParticleSystem[5];

	public int sequenceNumber;

	public TorchEvent torchList;

	public AudioSource audio;
	
	private IEnumerator ChangeLight(int value, int index) {
		var main = torchEffects[index].main;
		while (main.maxParticles != value) {
			main.maxParticles = (int)Mathf.Lerp(main.maxParticles, value, 200 * Time.deltaTime);
			yield return null;
		}
	}

	private IEnumerator ChangeColor(int index) {
		var main = torchEffects[index].main;
		var startTime = 0f;
		var endTime = 1f;
		while (startTime < endTime) {
			main.startColor = Color.Lerp(main.startColor.color, Color.green, 200 * Time.deltaTime);
			startTime += Time.deltaTime;
			yield return null;
		}
	}
	
	public void ChangeMaxParticles(int value) {
		for (var i = 0; i < torchEffects.Length; i++) {
			StartCoroutine(ChangeLight(value, i));
		}
	}

	public void ChangeParticleColor(int index) {
		for (int i = 0; i < torchEffects.Length; i++) {
			StartCoroutine(ChangeColor(i));
		}
	}

	public void Use() {
		ChangeMaxParticles(1000);
		torchList.AddTorchToSolutionList(sequenceNumber);
		audio.Play();
	}

	public string GetPrompt() {
		return "Light torch";
	}

	public Button CustomSprite() {
		return null;
	}

	
	
}
	

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class InteractableTorch : MonoBehaviour, IInteractable {

	public ParticleSystem[] torchEffects = new ParticleSystem[5];
	public string prompt;
	public Button button;
	public AudioSource audio;

	private void Awake() {
		audio = GetComponent<AudioSource>();
	}
	
	public abstract void Use();

	public abstract string GetPrompt();

	public Button CustomSprite() {
		return button;
	}
	
	protected IEnumerator ChangeLight(int value, int index) {
		var main = torchEffects[index].main;
		while (main.maxParticles != value) {
			main.maxParticles = (int)Mathf.Lerp(main.maxParticles, value, 200 * Time.deltaTime);
			yield return null;
		}
	}
	
	protected IEnumerator ChangeColor(int index) {
		var main = torchEffects[index].main;
		var startTime = 0f;
		var endTime = 1f;
		while (startTime < endTime) {
			main.startColor = Color.Lerp(main.startColor.color, Color.green, 200 * Time.deltaTime);
			startTime += Time.deltaTime;
			yield return null;
		}
	}
}

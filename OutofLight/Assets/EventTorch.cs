using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventTorch : InteractableTorch {
	
	public int sequenceNumber;
	public TorchEvent torchList;
	
	public void ChangeMaxParticles(int value) {
		for (var i = 0; i < torchEffects.Length; i++) {
			StartCoroutine(ChangeLight(value, i));
		}
	}

	public void ChangeParticleColor(int value) {
		for (int i = 0; i < torchEffects.Length; i++) {
			StartCoroutine(ChangeColor(i));
		}
	}

	public override void Use() {
		ChangeMaxParticles(1000);
		torchList.AddTorchToSolutionList(sequenceNumber);
		audio.Play();
	}

	public override string GetPrompt() {
		return "Light torch";
	}

	public Button CustomSprite() {
		return null;
	}

	
	
}
	

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class TorchEvent : MonoBehaviour {

	public List<InteractableTorch> torches = new List<InteractableTorch>();

	public void StartEvent() {
		ShuffleList();
		StartCoroutine(ShowLightOrder());
	}
	
	public IEnumerator ShowLightOrder() {
		for (int i = 0; i < torches.Count; i++) {
			torches[i].ChangeMaxParticles(1000);
			yield return new WaitForSeconds(1);
			torches[i].ChangeMaxParticles(0);
			yield return new WaitForSeconds(2);
			
		}
	}

	public void ShuffleList() {
		for (int i = 0; i < torches.Count; i++) {
			var random = Random.Range(0, torches.Count);
			var temp = torches[random];
			torches[random] = torches[i];
			torches[i] = temp;
		}
	}
	
}

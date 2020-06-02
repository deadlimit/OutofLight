using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TorchEvent : MonoBehaviour {

	public List<EventTorch> torches = new List<EventTorch>();
	public int[] correctOrder;

	public int[] chosenOrder;

	public GameEvent TorchChallengeComplete;

	private int turn;
	
	public void StartEvent() {
		turn = 0;
		correctOrder = new int[torches.Count];
		chosenOrder = new int[torches.Count];
		ShuffleList();
		AssignCorrectOrder();
		StartCoroutine(ShowLightOrder());
	}
	
	public IEnumerator ShowLightOrder() {
		yield return new WaitForSeconds(2);
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

	private void AssignCorrectOrder() {
		for (int i = 0; i < torches.Count; i++) {
			correctOrder[i] = torches[i].sequenceNumber;
		}
	}

	public void AddTorchToSolutionList(int sequenceNumber) {
		try {
			chosenOrder[turn] = sequenceNumber;
			turn++;
			CheckICorrect();
		}
		catch (IndexOutOfRangeException e) {
			
		}
		
	}

	private void CheckICorrect() {
		if (chosenOrder.Contains(0)) return;

		for (int i = 0; i < chosenOrder.Length; i++) {
			if (chosenOrder[i] != correctOrder[i]) {
				ResetEvent();
				return;
			}
		}
		ShowWinColor();
		TorchChallengeComplete.Raise();
	}

	private void ResetEvent() {
		foreach (var torch in torches) {
			torch.ChangeMaxParticles(0);
		}
		
		StartEvent();
		
	}

	private void ShowWinColor() {
		for (int i = 0; i < torches.Count; i++) {
			torches[i].ChangeParticleColor(i);
		}
	}
	
}

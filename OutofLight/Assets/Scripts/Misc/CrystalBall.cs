﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Experimental.TerrainAPI;
using UnityEngine.UI;

public class CrystalBall : MonoBehaviour, IInteractable {

	public string canUseStairs;
	public ParticleSystem particles;
	public Light light;
	public GameObject Barrier;
	private void Awake() {
		if (RequirementManager.Instance.CheckSpecificRequirements(canUseStairs)) {
			light.enabled = false;
			particles.gameObject.SetActive(false);
			gameObject.layer = LayerMask.GetMask("Default");
		}
		
	}
	
	public void Use() {
		StartCoroutine(LowerLight());
	}

	public string GetPrompt() {
		return "Deactivate";
	}

	public Button CustomSprite() {
		return null;
	}

	private IEnumerator LowerLight() {
		var main = particles.main;
		while (main.maxParticles > 1) {
			main.maxParticles -= 30;
			light.intensity -= Time.deltaTime * 50;
			yield return null;
		}
		
		RequirementManager.Instance.FulfillRequirement(canUseStairs, true);
		Destroy(Barrier);
		gameObject.layer = LayerMask.GetMask("Default");
	}
}

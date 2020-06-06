using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DeactivateBarrier : MonoBehaviour {

	public List<GameObject> barriers = new List<GameObject>();
	public string canUseStairs;

	public void Awake() {
		if (!RequirementManager.Instance.CheckSpecificRequirements(canUseStairs)) return;
		foreach (var obj in barriers)
			Destroy(obj);
		
		Destroy(gameObject);
	}

}

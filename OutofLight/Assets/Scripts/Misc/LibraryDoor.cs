using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryDoor : MonoBehaviour {

	public string canEnterLibrary;
	public Animator anim;
	public void Awake() {
		if (RequirementManager.Instance.CheckSpecificRequirements(canEnterLibrary))
			anim.enabled = true;
		else {
			anim.enabled = false;
		}
	}
	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryDoor : MonoBehaviour {

	public BoolVariable canEnterLibrary;
	public Animator anim;
	public void Awake() {
		if (canEnterLibrary.IsTrue())
			anim.enabled = true;
		else {
			anim.enabled = false;
		}
	}
	
}

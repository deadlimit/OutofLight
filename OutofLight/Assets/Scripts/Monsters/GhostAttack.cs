using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAttack : MonoBehaviour {

	public Animator anim;
	public int lowerValue;
	public IntVariable steps;
	
	private void Awake() {
		anim = GetComponentInParent<Animator>();
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			anim.SetTrigger("Attack");
			steps.ChangeValue(lowerValue);
		} 
	}

	
}

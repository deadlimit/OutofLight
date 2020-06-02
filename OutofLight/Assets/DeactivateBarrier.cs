using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DeactivateBarrier : MonoBehaviour {

	public GameObject barrierOne;
	public GameObject barrierTwo;
	public GameObject barrierThree;
	public BoolVariable CanUseStairs;

	public void Awake() {
		if (CanUseStairs.IsTrue()) {
			Destroy(barrierOne);
			Destroy(barrierTwo);
			Destroy(barrierThree);
			Destroy(gameObject);
		}
		
		
	}

}

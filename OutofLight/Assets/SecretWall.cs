using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretWall : MonoBehaviour {

	public Transform wallOne;

	public float newY;
	
	public void RotateWalls() {
		wallOne.LeanRotateY(newY, 2);
	}

	public void RotateBack() {
		wallOne.LeanRotateY(0, 2);
	}
	
}

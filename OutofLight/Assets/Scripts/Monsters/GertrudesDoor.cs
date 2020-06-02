using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GertrudesDoor : MonoBehaviour {

	public Transform doorToGetrudesRoom;
	public BoolVariable canEnterRoom;
	
	public void Awake() {
		if (canEnterRoom.IsTrue()) {
			doorToGetrudesRoom.position = new Vector3(6.618f, 0.85f, 2.814f);
			doorToGetrudesRoom.rotation = Quaternion.Euler(-90, 180, -26);
		}
		
	}

}

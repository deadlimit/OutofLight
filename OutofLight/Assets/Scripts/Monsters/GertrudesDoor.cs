using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GertrudesDoor : MonoBehaviour {

	public Transform doorToGetrudesRoom;
	public string canEnterRoom;
	public BoxCollider doorCollider;
	
	public void Awake() {
		if (RequirementManager.Instance.CheckSpecificRequirements(canEnterRoom)) {
			var center = doorCollider.center;
			doorToGetrudesRoom.position = new Vector3(6.618f, 0.85f, 2.814f); 
			doorToGetrudesRoom.rotation = Quaternion.Euler(-90, 180, -26);
			doorCollider.center = center;
		}
	}

}

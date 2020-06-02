using UnityEngine;

public class GhostTrigger : MonoBehaviour {
	
	public BoolVariable CanUseStairs;
	private void Awake() {
		if (CanUseStairs.IsTrue())
			Destroy(gameObject);
	}

}

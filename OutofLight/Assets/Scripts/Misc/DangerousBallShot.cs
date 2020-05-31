using UnityEngine;

public class DangerousBallShot : MonoBehaviour {

	public Vector3 target;
	public float moveSpeed;
	public GameEvent HitByTrap;

	public void Update() {
		transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
		if(Vector3.Distance(transform.position, target) < .1f)
			Destroy(gameObject);
	}
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			HitByTrap.Raise();
			Destroy(gameObject);
		}
	}
}

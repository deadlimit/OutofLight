using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousBallSpecial : MonoBehaviour
{
	public GameEvent HitByTrap;
	public float moveSpeed;

	private Vector3 destination;
	private bool arrived;
	private void Update()
	{
		Move();
	}

	public void Move()
	{
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, 14), moveSpeed * Time.deltaTime);
		destination = new Vector3(transform.position.x, transform.position.y, 14);
		if (transform.position.Equals(destination))
		{
			Destroy(gameObject);
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			HitByTrap.Raise();
			Destroy(gameObject);
		}
	}


}

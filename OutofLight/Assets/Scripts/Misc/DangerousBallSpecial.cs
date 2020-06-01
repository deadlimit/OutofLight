using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousBallSpecial : MonoBehaviour
{
	public GameEvent HitByTrap;
	public float moveSpeed;

	private void Update()
	{
		Move();
	}

	public void Move()
	{
		transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0f, 14), moveSpeed * Time.deltaTime);
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

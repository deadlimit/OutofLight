using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerousBallSpecial : MonoBehaviour
{
	public GameEvent HitByTrap;
	public float moveSpeed;
	public GuestRoomEvent target;

	private Transform thisTransform;
	private Vector3 thisTarget;
	private void Awake()
	{
		//Move();
	}

	private void Move()
	{
		StartCoroutine(MoveEnemy());
	}
	private IEnumerator MoveEnemy()
	{

		for (int i = 0; i < target.target.Length; i++)
		{
			thisTarget = target.target[i];
			while (Vector3.Distance(thisTransform.position, thisTarget) > .01f)
			{
				thisTransform.position =
					Vector3.MoveTowards(thisTransform.position, thisTarget, Time.deltaTime * moveSpeed);
				yield return null;
			}
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

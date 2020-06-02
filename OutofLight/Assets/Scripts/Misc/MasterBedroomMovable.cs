using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBedroomMovable : MonoBehaviour
{
	public Vector3 destination;
	public Quaternion rotate;

	private AudioSource audio;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
	}
	public void Method()
	{
		StartCoroutine(IMove());
		if (gameObject.CompareTag("LockedMBDoor"))
		{
			OpenDoor();
			audio.Play();
		}
		if (gameObject.CompareTag("MBSecretDoor"))
		{
			audio.Play();
		}
	}

	private IEnumerator IMove()
	{
		var target = transform.position + destination;
		while (Vector3.Distance(transform.position, target) > .01f)
		{
			transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime / 2);
			yield return null;
		}
	}

	public void OpenDoor()
	{
		transform.rotation = rotate;
	}
}
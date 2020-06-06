using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterBedroomMovable : MonoBehaviour
{
	public Vector3 destination;
	public Quaternion rotate;

	private AudioSource audio;
	public bool wallMoved;
	private void Awake()
	{
		audio = GetComponent<AudioSource>();
		wallMoved = false;
	}
	public void Method()
	{
		if (wallMoved == false)
		{
			StartCoroutine(IMove());
			if (gameObject.CompareTag("LockedMBDoor"))
			{
				OpenDoor();
				audio.Play();
			}
			if (gameObject.CompareTag("MBSecretDoor"))
			{
				if (wallMoved == false)
				{
					audio.Play();
					wallMoved = true;
				}				
			}
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
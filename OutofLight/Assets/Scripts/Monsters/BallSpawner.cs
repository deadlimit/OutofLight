using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour {

	public GameObject ball;
	public GameObject warning;
	public Tile[] startTiles = new Tile[4];
	public Tile[] endTiles = new Tile[4];

	public int spawnrate;
	
	private float startTime;
	private bool canShoot;
	
	private void Awake() {
		canShoot = false;
		startTime = 0;
	}
	
	private void Update() {
		if (canShoot) {
			canShoot = false;
			StartCoroutine(Spawn());
		}
		
	}

	public void StartShooting() {
		canShoot = true;
	}
	
	private IEnumerator Spawn() {
		var randomSpawnPoint = Random.Range(0, startTiles.Length);
		var startPos = startTiles[randomSpawnPoint].transform.position + new Vector3(0, .7f, 0);
		GameObject[] preWarnings = new GameObject[3];
		for (int i = 0; i < 3; i++) {
			var preWarning = Instantiate(warning, startPos + new Vector3(0, -.7f, 0), Quaternion.identity);
			preWarnings[i] = preWarning;
			yield return new WaitForSeconds(.5f);
		}
		
		yield return new WaitForSeconds(1f);
		
		var endPos = endTiles[randomSpawnPoint].transform.position + new Vector3(0, .7f, 0);
			var spawnedBall = Instantiate(ball, startPos, Quaternion.Euler(-90, 0 , 0));
			spawnedBall.GetComponent<DangerousBallShot>().target = endPos;
			
			
		yield return new WaitForSeconds(.5f);	
			
		foreach(var preWarning in preWarnings)
			Destroy(preWarning);
		
		StartShooting();
	}
	
}

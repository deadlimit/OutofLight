using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallSpawner : MonoBehaviour {

	public GameObject ball;
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
		if (canShoot && startTime > spawnrate) {
			Spawn();
			startTime = 0;
		}

		startTime += Time.deltaTime;
		
	}

	public void StartShooting() {
		canShoot = true;
	}
	
	private void Spawn() {
		var randomSpawnPoint = Random.Range(0, startTiles.Length);
		var startPos = startTiles[randomSpawnPoint].transform.position + new Vector3(0, .7f, 0);
		var endPos = endTiles[randomSpawnPoint].transform.position + new Vector3(0, .7f, 0);
			var spawnedBall = Instantiate(ball, startPos, Quaternion.identity);
			spawnedBall.GetComponent<DangerousBallShot>().target = endPos;
	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestRoomEvent : MonoBehaviour

{
    public GameObject enemy;
    public GameObject[] enemyWave = new GameObject[7];
    public Vector3[] spawnPoint = new Vector3[7];
    public Vector3[] target = new Vector3[7];
    public bool waveSpawned;
    public float moveSpeed;

    private Vector3 _target;
    private void Awake()
    {
        for (int i = 0; i < enemyWave.Length; i++)
        {
            enemyWave[i] = enemy;
        }
    }

    private void Start()
    {
        waveSpawned = false;
    }
    private void Update()
    {
        if (!waveSpawned)
        {
            SpawnEnemy(enemy);
            waveSpawned = true;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        for (int i = 0; i < enemyWave.Length; i++)
        {
            Instantiate(enemyWave[i], spawnPoint[i], Quaternion.identity);
            for (int j = 0; j < target.Length; j++)
            {
                _target = target[j];
            }
            this.transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * moveSpeed);
            if (Vector3.Distance(transform.position, _target) < .1f)
                Destroy(gameObject);

        }
    }
}

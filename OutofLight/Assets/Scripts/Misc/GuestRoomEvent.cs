using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestRoomEvent : MonoBehaviour

{
    public GameObject enemy;
    public GameObject[] enemyWave = new GameObject[7];
    public Vector3[] spawnPoint = new Vector3[7];
    public bool waveSpawned;
    public bool pagePickedUp;

    private void Awake()
    {
        pagePickedUp = false;
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
        if (!waveSpawned && pagePickedUp == true)
        {
            SpawnEnemy(enemy);
            waveSpawned = true;
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        for (int i = 0; i < enemyWave.Length; i++)
        {
            Instantiate(enemyWave[i], spawnPoint[i], Quaternion.Euler(270f, 40f, -40f));
        }
    }

    public void pickedUpPage()
    {
        pagePickedUp = true;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
        pagePickedUp = true;
    }
}

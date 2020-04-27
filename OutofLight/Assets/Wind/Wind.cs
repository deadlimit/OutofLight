using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    private ParticleSystem wind;

    private float startTime;
    private float endTime = 4;

    void Awake() {
        wind = GetComponent<ParticleSystem>();
    }

    void Update() {

        startTime += Time.deltaTime;

        if(startTime > endTime) {
            wind.Play();
            startTime = 0; 
        }

    }

    void OnParticleCollision(GameObject other) {
        if (other.CompareTag("Player")) {
            print("Player");
        }
    }


}

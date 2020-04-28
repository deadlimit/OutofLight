using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public GameEvent PlayerHitByWind;
    public IntVariable StepAmount;

    public int lossAmount;

    private ParticleSystem wind;
    private BoxCollider triggerCollider;
    private float startTime;
    private float endTime = 4;
    private bool trapActive;


    void Awake() {
        wind = GetComponent<ParticleSystem>();
        triggerCollider = GetComponent<BoxCollider>();
        trapActive = false;
    }

    void Update() {

        startTime += Time.deltaTime;

        if(startTime > endTime && !trapActive) {
            StartCoroutine(ActivateTrap());  
        }
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            StepAmount.ChangeValue(lossAmount);
        }
    }

    IEnumerator ActivateTrap() {
        trapActive = true;
        wind.Play();
        triggerCollider.enabled = true;

        yield return new WaitForSeconds(endTime / 2);
        startTime = 0; 
        trapActive = false;
        triggerCollider.enabled = false;
    }


}

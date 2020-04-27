using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

    private Transform _transform;
    public GameEvent FuelPickedUp;
    public IntVariable stepAmount;

    [SerializeField]
    private int refillAmount;

    void Awake() {
        _transform = GetComponent<Transform>(); 
    }

    void Update() {
        Rotate();
    }

    private void Rotate(){
        Vector3 angle = new Vector3(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));

        _transform.Rotate(angle * Time.deltaTime / 10, Space.World);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            FuelPickedUp.Raise();
            stepAmount.ChangeValue(refillAmount);
            Destroy(gameObject);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour {

    private Transform _transform;
    public GameEvent FuelPickedUp;
    public IntVariable stepAmount;
    public bool rotate;

    [SerializeField]
    private int refillAmount;

    private void Awake() {
        _transform = GetComponent<Transform>(); 
    }

    private void Update() {
        if (rotate)
            Rotate();
    }

    private void Rotate(){
        var angle = new Vector3(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));

        _transform.Rotate(angle * Time.deltaTime / 10, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        FuelPickedUp.Raise();
        stepAmount.ChangeValue(+refillAmount);
        Destroy(gameObject);
    }

}

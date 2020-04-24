using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

    public BoolVariable InsideSafezone;

    [SerializeField][Header("Initialt värde vid start")]
    private bool insideSafezone;

    void Start() {
        InsideSafezone.ChangeValue(insideSafezone);
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            InsideSafezone.ChangeValue(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            InsideSafezone.ChangeValue(false);
        }
    }

    

}

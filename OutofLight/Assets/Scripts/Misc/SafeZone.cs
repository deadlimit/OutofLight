using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

    public BoolVariable InsideSafezone;
    public IntVariable stepAmount;
    public IntVariable darkSteps;

    [SerializeField][Header("Initialt värde vid start")]
    private bool insideSafezone;
    [SerializeField][Header("Påfyll av steg")]
    private int refillStepAmount;
    [SerializeField]
    [Header("Borttag av Dark Steps")]
    private int removeAmount;

    private void Start() {
        InsideSafezone.ChangeValue(insideSafezone);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        InsideSafezone.ChangeValue(true);
        if (stepAmount.GetValue() < refillStepAmount)
            stepAmount.ChangeValue(+refillStepAmount);
        if (darkSteps.GetValue() >= 0)
        {
            darkSteps.ChangeValue(-removeAmount);
        }
        
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            InsideSafezone.ChangeValue(false);
        }
    }

    

}

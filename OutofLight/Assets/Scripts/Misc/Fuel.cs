using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour, IInteractable {

    private Transform _transform;
    public GameEvent FuelPickedUp;
    public IntVariable stepAmount, darkStepAmount;

    [SerializeField]
    private int refillAmount;

    private void Awake() {
        _transform = GetComponent<Transform>(); 
    }

    
    public void Use() {
        FuelPickedUp.Raise();
        stepAmount.ChangeValue(+refillAmount);
        Destroy(transform.parent.gameObject);
        darkStepAmount.ChangeValue(-6);
    }

    public string GetPrompt() {
        return "Pick up fuel";
    }

    public Button CustomSprite() {
        return null;
    }
}

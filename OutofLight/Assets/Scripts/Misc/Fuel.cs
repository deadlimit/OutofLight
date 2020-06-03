﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour, IInteractable {

    private Transform _transform;
    public GameEvent FuelPickedUp;
    public IntVariable stepAmount, darkStepAmount;
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
        var angle = new Vector3(Random.Range(0, 90), Random.Range(-45, 45), Random.Range(-45, 45));

        _transform.Rotate(angle * Time.deltaTime / 10, Space.World);
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

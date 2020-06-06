using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour, IInteractable {

    public GameEvent FuelPickedUp;
    public IntVariable stepAmount, darkStepAmount;
    public AudioSource audio;

    [SerializeField]
    private int refillAmount;
    private void Awake() {
        audio = GetComponent<AudioSource>();
    }

    
    public void Use() {
        FuelPickedUp.Raise();
        audio.Play();
        stepAmount.ChangeValue(+refillAmount);
        GetComponent<SphereCollider>().enabled = false;
        Destroy(transform.parent.gameObject, 1.5f);
        darkStepAmount.ChangeValue(-6);
    }

    public string GetPrompt() {
        return "Pick up fuel";
    }

    public Button CustomSprite() {
        return null;
    }
}

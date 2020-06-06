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
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 100f);
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

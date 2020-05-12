using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    public Text amountOfStepsText, gameStateText, darkStepsText;
    public GameState gameState;
    public IntVariable steps, darkSteps;
    public Image fadeImage;
    public GameObject returnB;
    public GameObject interactB;

    private void Start() {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0.1f, 3f, false);
        returnB = GameObject.Find("ReturnToMenuButton");
        returnB.gameObject.SetActive(true);
        interactB = GameObject.Find("InteractButton");
        interactB.gameObject.SetActive(false);
    }

    private void Update() {
        UpdateGameState();
        UpdateSteps();
        UpdateDarkSteps();
    }


    private void UpdateGameState() {
        gameStateText.text = "Game State: " + gameState.CurrentState();
    }

    private void UpdateSteps() {
        amountOfStepsText.text = "Steps: " + steps.GetValue();
    }

    private void UpdateDarkSteps()
    {
        darkStepsText.text = "Dark Steps: " + darkSteps.GetValue();
    }
}

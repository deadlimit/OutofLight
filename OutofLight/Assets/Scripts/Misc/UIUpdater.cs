using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    public Text amountOfStepsText, gameStateText, darkStepsText;
    public GameState gameState;
    public IntVariable steps, darkSteps;
    public Image fadeImage;

    void Start() {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0.1f, 3f, false);
    }

    void Update() {
        UpdateGameState();
        UpdateSteps();
        UpdateDarkSteps();
    }


    public void UpdateGameState() {
        gameStateText.text = "Game State: " + gameState.CurrentState();
    }

    public void UpdateSteps() {
        amountOfStepsText.text = "Steps: " + steps.GetValue();
    }

    public void UpdateDarkSteps()
    {
        darkStepsText.text = "Dark Steps: " + darkSteps.GetValue();
    }
}

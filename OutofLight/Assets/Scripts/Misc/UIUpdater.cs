using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

    public Text amountOfStepsText, gameStateText;
    public GameState gameState;
    public IntVariable steps;

    void Start() {
        UpdateGameState();
        UpdateSteps();
    }


    public void UpdateGameState() {

        gameStateText.text = "Game State: " + gameState.CurrentState();
        print("Update State raised!");
    }

    public void UpdateSteps() {
        amountOfStepsText.text = "Steps: " + steps.GetValue();
        print("Update Steps raised!");
    }

}

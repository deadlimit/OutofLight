using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIUpdater : MonoBehaviour {

    public Text amountOfStepsText, gameStateText, darkStepsText, roomText;
    public GameState gameState;
    public IntVariable steps, darkSteps;
    public Image fadeImage;
    public GameObject returnB;

    private void Start() {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0.1f, 3f, false);
        returnB = GameObject.Find("ReturnToMenuButton");
        returnB.gameObject.SetActive(true);
        roomText.enabled = true;
        roomText.CrossFadeAlpha(0.1f, 5f, false);
    }

    private void Update() {
        UpdateGameState();
        UpdateSteps();
        UpdateDarkSteps();
        DisplayScene();
    }

    private void DisplayScene()
    {
        roomText.text = SceneManager.GetActiveScene().name;
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

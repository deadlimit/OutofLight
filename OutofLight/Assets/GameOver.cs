using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameState gameState;
    public IntVariable stepAmount;

    void Awake() {
        gameState.EnterLightMode();
    }

    public void CheckIfGameOver() {
        if (stepAmount.GetValue() <= 0 && gameState.CurrentState() == State.DARK) {
            SceneManager.LoadScene(0);
        }
    }

}

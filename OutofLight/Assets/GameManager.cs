using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameState state;

    public void ChangeDarknessMode() {
        state.EnterDarkMode();
    }

    public void GameOver() {
        SceneManager.LoadScene(0);
    }

}

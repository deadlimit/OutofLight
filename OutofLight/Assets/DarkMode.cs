using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMode : MonoBehaviour {

    public GameState gameState;

    void Awake() {
        gameState.SwitchState(State.LIGHT); 
    }

    public void EnterDarkMode() {
        gameState.SwitchState(State.DARK);
    }

}

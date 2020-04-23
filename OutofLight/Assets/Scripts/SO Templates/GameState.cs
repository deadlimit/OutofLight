using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject {

    [SerializeField]
    private State gameState;
    

    public void EnterDarkMode() {
        gameState = State.DARK;
    }

    public void EnterLightMode() {
        gameState = State.LIGHT;
    }


    public State CurrentState() {
        return gameState;
    }
}


public enum State {
    LIGHT,
    DARK,
}

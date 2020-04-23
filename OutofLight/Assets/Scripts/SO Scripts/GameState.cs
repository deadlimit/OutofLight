using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject{

    [SerializeField]
    private State gameState;
    
    public void SwitchState(State newState) {
        gameState = newState;
    }

    public State CurrentState() {
        return gameState;
    }
}


public enum State {
    LIGHT,
    DARK,
}

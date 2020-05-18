using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour {

    public GameEvent stepsDepleted;
    public BoolVariable safezone;
    public IntVariable stepAmount;
    public GameState gameState;
    public IntVariable darkStepAmount;

    [SerializeField]
    private int startingStepsAmount;
    [SerializeField]
    private int startingDarkSteps;

    private void Awake() {
        stepAmount.ChangeValue(-100);
        stepAmount.ChangeValue(startingStepsAmount);
        darkStepAmount.ChangeValue(-100);
        darkStepAmount.ChangeValue(startingDarkSteps);
        gameState.EnterLightMode();
    }

    private void Update()
    {
        CheckIfStepsDepleted();
        
    }

    public void DecrementStep()
    {
        if (safezone.IsTrue()) return;
        stepAmount.ChangeValue(-1);
        if (stepAmount.GetValue() <= 0)
        {
            gameState.EnterDarkMode();
        }

    }
    public void AddDarkStep()
    {
        if (gameState.CurrentState() != State.DARK || safezone.IsTrue()) return;

        darkStepAmount.ChangeValue(+1);
        Debug.Log("Dark Steps Is: " + darkStepAmount.GetValue());
    }

    private void CheckIfStepsDepleted() {
        if (stepAmount.GetValue() <= 0)
            stepsDepleted.Raise();
        if (stepAmount.GetValue() > 0)
        {
            gameState.EnterLightMode();
        }
    }


}

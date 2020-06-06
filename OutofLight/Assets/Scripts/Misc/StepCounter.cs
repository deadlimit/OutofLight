using UnityEngine;
using UnityEngine.UI;

public class StepCounter : MonoBehaviour {

    public GameEvent stepsDepleted, gameOver;
    public BoolVariable safezone;
    public IntVariable stepAmount;
    public GameState gameState;
    public IntVariable darkStepAmount;

    [SerializeField]
    private int startingStepsAmount;
    [SerializeField]
    private int startingDarkSteps;

    private bool menuDisplayed;

    private void Awake() {
        stepAmount.ChangeValue(-1000);
        stepAmount.ChangeValue(startingStepsAmount);
        darkStepAmount.ChangeValue(-1000);
        darkStepAmount.ChangeValue(startingDarkSteps);
        gameState.EnterLightMode();
        menuDisplayed = false;
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
    }

    private void CheckIfStepsDepleted() {
        if (stepAmount.GetValue() <= 0)
            stepsDepleted.Raise();
        if (stepAmount.GetValue() > 0)
        {
            gameState.EnterLightMode();
        }
        if (darkStepAmount.GetValue() == 7 && !menuDisplayed)
        {
            gameOver.Raise();
            menuDisplayed = true;
        }
    }


}

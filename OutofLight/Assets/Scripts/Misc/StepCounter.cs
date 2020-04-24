using UnityEngine;

public class StepCounter : MonoBehaviour {

    public GameEvent StepsDepleted;

    public IntVariable stepAmount;

    [SerializeField]
    private int startingSteps;

    void Awake() {
        stepAmount.SetNewValue(startingSteps);
    }   

    public void DecrementStep() {
        stepAmount.DecrementValue();
        print("Decrement step raised!");
    }
    
    public void CheckIfStepsDepleted() {
        if (stepAmount.GetValue() <= 0)
            StepsDepleted.Raise();

        print("Check if step raised!");
    }


}

using UnityEngine;

public class StepCounter : MonoBehaviour {

    public GameEvent stepsDepleted;
    public BoolVariable safezone;
    public IntVariable stepAmount;

    [SerializeField]
    private int startingStepsAmount;

    void Awake() {
        stepAmount.ChangeValue(-100);
        stepAmount.ChangeValue(startingStepsAmount);
    }   

    public void DecrementStep() {
        if (!safezone.IsTrue()) {
            stepAmount.DecrementValue();
        }
        
    }
    
    public void CheckIfStepsDepleted() {
        if (stepAmount.GetValue() <= 0)
            stepsDepleted.Raise();
    }


}

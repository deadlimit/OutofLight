using UnityEngine;

public class StepCounter : MonoBehaviour {

    public GameEvent StepsDepleted;

    public IntVariable LightSteps;

    [SerializeField]
    private int startingSteps;

    void Awake() {
        LightSteps.SetNewValue(startingSteps);
    }   

    public void DecrementStep() {
        LightSteps.DecrementValue();
        CheckIfStepsDepleted();
    }
    
    private void CheckIfStepsDepleted() {
        if (LightSteps.GetValue() <= 0)
            StepsDepleted.Raise();
    }


}

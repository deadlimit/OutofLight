using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCounter : MonoBehaviour {

    public GameEvent StepsDepleted;

    public IntVariable Steps;

    [SerializeField]
    private int startingSteps;

    void Awake() {
        Steps.SetNewValue(startingSteps);
    }

    public void DecrementStep() {
        if (Steps.GetValue() <= 0)
            StepsDepleted.Raise();
        else
            Steps.DecrementValue();
    }

}

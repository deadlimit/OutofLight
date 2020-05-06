using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCreep : MonoBehaviour
{
    public Image creep;
    public GameState gameState;
    public IntVariable darkStepAmount;
    public float creepDuration;

    void Start()
    {
        creep.enabled = false;
    }

    void Update()
    {
        if (gameState.CurrentState() == State.DARK && darkStepAmount.GetValue() >= 3)
        {
            creep.enabled = true;
        }
        CreepState();
    }

    private void CreepState()
    {
        if (darkStepAmount.GetValue() == 4)
        {
            creep.CrossFadeAlpha(125f, creepDuration, false);
        }

        if (darkStepAmount.GetValue() == 5)
        {
            creep.CrossFadeAlpha(200f, creepDuration, false);
        }

        if (darkStepAmount.GetValue() >= 6)
        {
            creep.CrossFadeAlpha(255f, creepDuration, false);
        }
        else creep.CrossFadeAlpha(0.1f, creepDuration, false);
    }


}

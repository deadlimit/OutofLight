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
    public Color lowTarget, middleTarget, highTarget, current;

    private void Start()
    {
        creep.enabled = false;

    }

    private void Update()
    {
        if (gameState.CurrentState() == State.DARK && darkStepAmount.GetValue() >= 3)
        {
            creep.enabled = true;
        }
        CreepState();
        current = creep.color;
    }

    private void CreepState()
    {
        if (darkStepAmount.GetValue() == 4)
        {
            creep.color = Color.Lerp(current, lowTarget, Time.deltaTime * creepDuration);
        }

        if (darkStepAmount.GetValue() == 5)
        {
            creep.color = Color.Lerp(current, middleTarget, Time.deltaTime * creepDuration);
        }

        if (darkStepAmount.GetValue() >= 6)
        {
            creep.color = Color.Lerp(current, highTarget, Time.deltaTime * creepDuration);
        }
    }


}

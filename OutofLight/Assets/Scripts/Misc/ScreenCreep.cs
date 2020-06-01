using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenCreep : MonoBehaviour
{
    public Image creep;
    public GameState gameState;
    public IntVariable darkStepAmount;
    public float creepDuration;
    public Color lowTarget, middleTarget, highTarget, current, disabled;
    public AudioSource dave;
    public AudioClip heartbeat;
    private void Start()
    {
        creep.enabled = false;
        dave = GameObject.FindWithTag("Player").GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        if (gameState.CurrentState() == State.DARK && darkStepAmount.GetValue() >= 3)
        {
            creep.enabled = true;
            //PlayHeartbeat();
        }
        CreepState();
        current = creep.color;
    }

    private void CreepState()
    {
        if (darkStepAmount.GetValue() < 4)
        {
            creep.color = Color.Lerp(current, disabled, Time.deltaTime * creepDuration);
        }
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

    public void PlayHeartbeat()
    {
        dave.PlayOneShot(heartbeat);
    }


}

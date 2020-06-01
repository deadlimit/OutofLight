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
    public AudioSource audio;
    public AudioClip heartbeat;
    public GameEvent creepActive, deathByDarkness;

    private bool death;
    private void Start()
    {
        death = false;
        creep.enabled = false;
    }

    private void Update()
    {
        if (gameState.CurrentState() == State.DARK && darkStepAmount.GetValue() >= 3)
        {
            creep.enabled = true;
        }
        if (!audio.isPlaying && darkStepAmount.GetValue() <= 4 && gameState.CurrentState() == State.DARK)
        {
            creepActive.Raise();
        }
        CreepState();
        current = creep.color;
    }

    private void CreepState()
    {
        if (darkStepAmount.GetValue() == 0)
        {
            audio.enabled = false;
        }
        if (darkStepAmount.GetValue() < 4)
        {
            creep.color = Color.Lerp(current, disabled, Time.deltaTime * creepDuration);
            audio.enabled = true;
            audio.volume = 0.2f;
        }
        if (darkStepAmount.GetValue() == 4)
        {
            creep.color = Color.Lerp(current, lowTarget, Time.deltaTime * creepDuration);
            audio.volume = 0.5f;
        }

        if (darkStepAmount.GetValue() == 5)
        {
            creep.color = Color.Lerp(current, middleTarget, Time.deltaTime * creepDuration);
            audio.volume = 0.7f;
        }

        if (darkStepAmount.GetValue() == 6)
        {
            creep.color = Color.Lerp(current, highTarget, Time.deltaTime * creepDuration);
            audio.volume = 1f;
        }
        if (darkStepAmount.GetValue() == 7)
        {
            creep.color = Color.Lerp(current, highTarget, Time.deltaTime * creepDuration);
            if (!death)
            {
                death = true;
                deathByDarkness.Raise();
            }
        }
    }

    public void PlayHeartbeat()
    {
        audio.PlayOneShot(heartbeat);
    }


}

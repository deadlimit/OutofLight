using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkmode : MonoBehaviour {

    public IntVariable stepAmount;

    public GameObject GameOver;

    [SerializeField]
    private int darksteps;

    private void Start() {
        GameOver.SetActive(false);
    }

    public void ActivateGameOver() {

        GameOver.SetActive(true);
    }

    public void AddDarknessSteps() {
        print("Added");
        stepAmount.ChangeValue(darksteps);
    }


}

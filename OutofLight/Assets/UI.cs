using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text stepCounter;
    public IntVariable Steps;

    void Start() {
        UpdateStepCounter();
    }
    
    public void UpdateStepCounter() {
        stepCounter.text = "Steps left: " + Steps.GetValue().ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour {

    public IntVariable stepsAmount;
    public Slider fuelSlider;
    private Light lanternLight;


    [SerializeField]
    private float decreaseLightModifier;

    void Awake() {
        lanternLight = GetComponentInChildren<Light>();
    }

    private void Start()
    {
        lanternLight.range = fuelSlider.maxValue;
    }

    private void Update()
    {
        if (stepsAmount.GetValue() >= 0)
        lanternLight.range = Mathf.Lerp(fuelSlider.value, stepsAmount.GetValue(), Time.deltaTime * decreaseLightModifier);
    }

    //Gammal, snyggare kod av Jonathan:
    //public void ChangeLight() {
        //StartCoroutine(DecreaseLight());
    //}



    //private IEnumerator DecreaseLight() {

        //float startTime = 0;
        //float endTime = 2;

        //while(startTime < endTime) {
            //lanternLight.range -= decreaseLightModifier * Time.deltaTime;
            //startTime += Time.deltaTime;
            //yield return null;
        //}
    //}

}

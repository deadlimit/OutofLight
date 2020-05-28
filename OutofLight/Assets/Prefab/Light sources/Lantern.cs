using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lantern : MonoBehaviour {

    public IntVariable stepsAmount;
    public Slider fuelSlider;
    public Light light1, light2;

    [SerializeField]
    private float decreaseLightModifier;

    private void Awake() {
        fuelSlider = GameObject.Find("FuelBar").GetComponent<Slider>();
    }

    private void Start()
    {
        light1.range = fuelSlider.maxValue;
        light2.range = fuelSlider.maxValue;
    }

    private void Update()
    {
        if (stepsAmount.GetValue() >= 0)
        {
            light1.range = Mathf.Lerp(fuelSlider.value, stepsAmount.GetValue(), Time.deltaTime * decreaseLightModifier);
            light2.range = Mathf.Lerp(fuelSlider.value, stepsAmount.GetValue(), Time.deltaTime * decreaseLightModifier);
        }
    }


}

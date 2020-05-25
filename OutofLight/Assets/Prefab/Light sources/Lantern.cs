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

    private void Awake() {
        lanternLight = GetComponentInChildren<Light>();
        fuelSlider = GameObject.Find("FuelBar").GetComponent<Slider>();
    }

    private void Start()
    {
        lanternLight.range = fuelSlider.maxValue;
    }

    private void Update()
    {
        if (stepsAmount.GetValue() >= 0)
        {
            lanternLight.range = Mathf.Lerp(fuelSlider.value, stepsAmount.GetValue(), Time.deltaTime * decreaseLightModifier);
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public IntVariable stepAmount;
    public Slider lanternSlider;
    public float lerpSpeed;

    private void Start()
    {
        lanternSlider = lanternSlider.GetComponent<Slider>();
        lanternSlider.maxValue = stepAmount.GetValue();
        lanternSlider.value = stepAmount.GetValue();
    }

    private void Update()
    {
        lanternSlider.value = Mathf.Lerp(lanternSlider.value, stepAmount.GetValue(), Time.deltaTime * lerpSpeed);
    }

}

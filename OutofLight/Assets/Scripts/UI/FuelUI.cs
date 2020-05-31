using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelUI : MonoBehaviour
{
    public IntVariable stepAmount;
    public Slider lanternSlider;
    public float lerpSpeed, lerpColor;
    public Image fill;
    public Color high, middle, low, currentColor;

    private float middleValue, lowValue;

    private void Start()
    {
        lanternSlider = lanternSlider.GetComponent<Slider>();
        lanternSlider.maxValue = stepAmount.GetValue();
        lanternSlider.value = stepAmount.GetValue();
        lanternSlider.interactable = false;
        SetColors();
    }

    private void Update()
    {
        lanternSlider.value = Mathf.Lerp(lanternSlider.value, stepAmount.GetValue(), Time.deltaTime * lerpSpeed);
        if (lanternSlider.value > middleValue)
        {
            currentColor = Color.Lerp(currentColor, high, Time.deltaTime * lerpColor);
        } 
        if (lanternSlider.value > lowValue && lanternSlider.value < middleValue)
        {
            currentColor = Color.Lerp(currentColor, middle, Time.deltaTime * lerpColor);
        }
        else if (lanternSlider.value < lowValue)
        {
            currentColor = Color.Lerp(currentColor, low, Time.deltaTime * lerpColor);
        }

        fill.color = currentColor;
    }

    private void SetColors()
    {
        middleValue = lanternSlider.maxValue * 0.75f;
        lowValue = lanternSlider.maxValue * 0.3f;
    }

}

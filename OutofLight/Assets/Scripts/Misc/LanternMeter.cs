using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternMeter : MonoBehaviour {

    private Slider lanternSlider;

    public IntVariable stepAmount;

    private void Awake() {
        lanternSlider = GetComponent<Slider>();
    }

    public void UpdateBar() {
        print("UPDATEBAR!");
    }

}

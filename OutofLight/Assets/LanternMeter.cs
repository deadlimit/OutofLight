using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternMeter : MonoBehaviour {

    private Slider lanternSlider;

    void Awake() {
        lanternSlider = GetComponent<Slider>();
    }

}

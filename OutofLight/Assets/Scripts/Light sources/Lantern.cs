using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour {

    private Light lanternLight;

    public Material lightCubeMaterial;

    [SerializeField]
    private float decreaseLightModifier;

    void Awake() {
        lanternLight = GetComponent<Light>();
    }

    public void ChangeLight() {
        StartCoroutine(DecreaseLight());
    }

    private IEnumerator DecreaseLight() {

        float startTime = 0;
        float endTime = 2;

        while(startTime < endTime) {
            lanternLight.range -= decreaseLightModifier * Time.deltaTime;
            startTime += Time.deltaTime;
            yield return null;
        }
    }

}

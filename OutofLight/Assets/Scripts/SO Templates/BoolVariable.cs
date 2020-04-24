using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject {

    [SerializeField]
    private bool isTrue;

    public void ChangeValue(bool value) {
        isTrue = value;
    }

    public bool GetValue() {
        return isTrue;
    }
}

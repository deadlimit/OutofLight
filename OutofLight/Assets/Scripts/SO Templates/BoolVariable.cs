using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject {

    [SerializeField]
    private bool isTrue;

    private void OnEnable() {
        Debug.Log("Enable" + this.name);
    }

    public void ChangeValue(bool value) {
        isTrue = value;
    }

    public bool IsTrue() {
        return isTrue;
    }
}

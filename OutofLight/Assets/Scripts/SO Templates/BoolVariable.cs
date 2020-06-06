using System;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject {

    public bool isTrue;

    public void OnEnable() {
        Debug.Log(name + " " + isTrue);
    }

    public void ChangeValue(bool value) {
        isTrue = value;
        Debug.Log(name + " changed value");
    }

    public bool IsTrue() {
        return isTrue;
    }
}

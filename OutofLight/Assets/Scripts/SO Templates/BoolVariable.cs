using System;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject {

    public bool isTrue;
    
    public void ChangeValue(bool value) {
        isTrue = value;
    }

    public bool IsTrue() {
        return isTrue;
    }
}

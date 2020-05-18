using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject {

    [SerializeField]
    private bool isTrue;

    public void ChangeValue(bool value) {
        isTrue = value;
    }

    public bool IsTrue() {
        return isTrue;
    }
}

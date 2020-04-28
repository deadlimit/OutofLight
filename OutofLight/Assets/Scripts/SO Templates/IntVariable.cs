﻿using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject {
    [SerializeField]
    private int value;

    public void ChangeValue(int value) {

        int newValue = this.value += value;

        if (newValue < 0)
            this.value = 0;
        else 
            this.value = newValue;
    }

    public int GetValue() {
        return value; 
    }




}

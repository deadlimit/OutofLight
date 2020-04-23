using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject {
    [SerializeField]
    private int value;

    public void SetNewValue(int value) {
        if (value < 0)
            this.value = 0;
        else
            this.value = value; 
    }

    public int GetValue() {
        return value; 
    }

    public void DecrementValue() {
        SetNewValue(--value);
    }

    public void IncrementValue() {
        SetNewValue(++value);
    }

}

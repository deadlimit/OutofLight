using UnityEngine;

[CreateAssetMenu]
public class IntVariable : ScriptableObject {
    [SerializeField]
    private int value;

    public void ChangeValue(int value) {
        if (value < 0)
            this.value = 0;
        else 
            this.value += value;
        
            
    }

    public int GetValue() {
        return value; 
    }

    public void DecrementValue() {
        --value;
    }

    public void IncrementValue() {
        ++value;
    }

}

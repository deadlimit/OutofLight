using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject {
    [SerializeField]
    private int value;

    public void ChangeValue(int value)
    {
        var newValue = this.value += value;

        this.value = newValue < 0 ? 0 : newValue;
    }

    public int GetValue() {
        return value; 
    }




}

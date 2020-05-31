using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private float value;

    public void ChangeValue(float value)
    {
        var newValue = this.value += value;

        this.value = newValue < 0f ? 0f : newValue;
    }

    public float GetValue()
    {
        return value;
    }




}

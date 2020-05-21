using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OptionalState : ScriptableObject
{
    [SerializeField]
    [Header("Är pilalaternativen ikryssade?")]
    private Optional optional;

    public void UseArrows()
    {
        optional = Optional.ARROWS;
    }

    public void DontUseArrows()
    {
        optional = Optional.NOARROWS;
    }

    public Optional CurrentOption()
    {
        return optional;
    }

}

public enum Optional
{
    ARROWS,
    NOARROWS,
}

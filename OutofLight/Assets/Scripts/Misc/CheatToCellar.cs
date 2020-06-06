using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatToCellar : MonoBehaviour
{
    public RequirementManager req;

    public List<string> requirementName = new List<string>();

    public Dictionary<string, bool> requirementList = new Dictionary<string, bool>();

    private void Awake()
    {
        foreach (var b in requirementList)
        {

        }
    }

}

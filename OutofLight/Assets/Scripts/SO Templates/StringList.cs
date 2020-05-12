using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class StringList : ScriptableObject
{
    [SerializeField]
    private string content;
    public StringList(string content)
    {
        this.content = content;
    }

    public string getText()
    {
        return content;
    }
}

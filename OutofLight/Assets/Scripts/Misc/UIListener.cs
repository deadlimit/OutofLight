using UnityEngine;

public class UIListener : MonoBehaviour
{

    public GameObject journalPageDisplay;

    public void DisplayPage()
    {
        var UITransform = GameObject.FindWithTag("UI").transform;
        Instantiate(journalPageDisplay, UITransform.position, Quaternion.identity, UITransform);
    }

}

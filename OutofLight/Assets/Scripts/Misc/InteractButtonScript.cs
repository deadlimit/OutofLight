using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButtonScript : MonoBehaviour
{
    public GameEvent doubleTap;
    public GameObject interact;

    private Touch input;
    private bool isClose;

    private void Start()
    {
        interact = GameObject.Find("InteractButton");
        interact.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isClose)
        {
            GetDoubleTap();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.gameObject.SetActive(true);
            isClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interact.gameObject.SetActive(false);
            isClose = false;
        }
    }

    private void GetDoubleTap()
    {
        if (input.tapCount != 2) return;
        doubleTap.Raise();
    }

}

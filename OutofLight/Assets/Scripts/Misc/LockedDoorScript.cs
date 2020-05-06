using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LockedDoorScript : MonoBehaviour
{
    public Text doorLocked, doorPartiallyLocked, doorUnlocked, finishedButtonText;
    public Image paper, returnButtonImage;
    public BoolVariable lever1, lever2, lever3;
    public Button returnToMenu;

    private bool isUnlocked;
    void Start()
    {
        doorLocked.enabled = false;
        doorPartiallyLocked.enabled = false;
        doorUnlocked.enabled = false;
        isUnlocked = false;
        returnToMenu.enabled = false;
        returnToMenu.interactable = false;
        finishedButtonText.enabled = false;
        returnButtonImage.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (lever1 && lever2 && lever3)
            {
                paper.enabled = true;
                doorLocked.enabled = true;
            }
            if (!lever1 && lever2 && lever3)
            {
                paper.enabled = true;
                doorPartiallyLocked.enabled = true;
            }
            if (!lever1 && !lever2 && lever3)
            {
                paper.enabled = true;
                doorPartiallyLocked.enabled = true;
            }
            else if (!lever1 && !lever2 && !lever3)
            {
                paper.enabled = true;
                doorUnlocked.enabled = true;
                isUnlocked = true;
                returnToMenu.enabled = true;
                returnToMenu.interactable = true;
                finishedButtonText.enabled = true;
                returnButtonImage.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            paper.enabled = false;
            doorLocked.enabled = false;
            doorPartiallyLocked.enabled = false;
            doorUnlocked.enabled = false;
            returnToMenu.enabled = false;
            returnToMenu.interactable = false;
            finishedButtonText.enabled = false;
        }
    }

    public void ButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

}

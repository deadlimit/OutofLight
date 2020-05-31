using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public Button  options, returnToMenu, returnToMainMenu, closeMenu;
    public Slider volumeController;
    public FloatVariable volumeVar;
    public GameObject optionsMenu;
    private bool freezeTime;
    public Movement movement;
    public TouchInput touch;


    private void Awake()
    {
        volumeController.maxValue = volumeVar.GetValue();
        volumeController.value = volumeVar.GetValue();
    }

    private void Start()
    {
        optionsMenu.SetActive(false);
        freezeTime = false;

    }

    private void Update()
    {
        if (volumeController.value < volumeVar.GetValue())
        {
            volumeVar.ChangeValue(-0.1f);
        }
        if (volumeController.value > volumeVar.GetValue())
        {
            volumeVar.ChangeValue(+0.1f);
        }
        if (freezeTime)
        {
            Time.timeScale = 0;
            movement.enabled = false;
            touch.enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            movement.enabled = true;
            touch.enabled = true;
        }
    }
    public void MenuButton()
    {
        optionsMenu.SetActive(true);
        options.gameObject.SetActive(true);
        closeMenu.gameObject.SetActive(true);
        returnToMenu.gameObject.SetActive(false);
        returnToMainMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(false);
        freezeTime = true;
    }
    public void Options()
    {
        options.gameObject.SetActive(false);
        closeMenu.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(true);
        returnToMainMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        options.gameObject.SetActive(true);
        closeMenu.gameObject.SetActive(true);
        returnToMenu.gameObject.SetActive(false);
        returnToMainMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(false);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CloseMenu()
    {
        optionsMenu.SetActive(false);
        freezeTime = false;
    }


}

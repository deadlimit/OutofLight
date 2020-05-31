using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image fadeImage;
    public Button newGame, options, exitGame, returnToMenu;
    public Slider volumeController;
    public FloatVariable volumeVar;

    private void Awake()
    {
        volumeController.maxValue = 1f;
        volumeController.value = volumeVar.GetValue();
    }
    private void Start()
    {
        fadeImage.enabled = false;
        newGame.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
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
    }
    public void NewGame()
    {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(255, 3f, false);
        if (fadeImage.color.a == 1f)
        {
           SceneManager.LoadScene(1);
        }
    }

    public void Options()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToMenu()
    {
        newGame.gameObject.SetActive(true);
        options.gameObject.SetActive(true);
        exitGame.gameObject.SetActive(true);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
    }
}

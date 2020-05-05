using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        fadeImage.enabled = false;
    }
    public void NewGame()
    {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(255f, 3f, false);
        if (fadeImage.color.a == 1f)
        {
           SceneManager.LoadScene(1);
        }

    }

    public void Options()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

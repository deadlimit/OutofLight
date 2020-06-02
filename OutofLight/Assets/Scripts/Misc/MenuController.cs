using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public Image fadeImage, howToPlayImage;
    public Button newGame, options, exitGame, returnToMenu, howTo;
    public Slider volumeController;
    public FloatVariable volumeVar;
    public IntVariable darkSteps;
    public TransitInfo transitInfo;
    public SpawnPosition spawn;
    public List<BoolVariable> progression = new List<BoolVariable>();
    public Text howToPlay;


    private void Awake()
    {
        spawn.spawnPosition = transitInfo.otherSide;
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
        howTo.gameObject.SetActive(true);
        howToPlay.gameObject.SetActive(false);
        howToPlayImage.gameObject.SetActive(false);
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
        try
        {
            foreach (var e in progression)
            {
                e.ChangeValue(false);
            }
        }
        catch (MissingComponentException e)
        {
            print(e.Message);
        }
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(255, 3f, false);
        darkSteps.ChangeValue(-7);
        if (fadeImage.color.a == 1f)
        {
           SceneManager.LoadScene(transitInfo.sceneNumber);
        }
    }

    public void Options()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(true);
        howTo.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(false);
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
        howTo.gameObject.SetActive(true);
        howToPlay.gameObject.SetActive(false);
        howToPlayImage.gameObject.SetActive(false);
        howToPlayImage.gameObject.SetActive(false);
    }

    public void HowToPlay()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(false);
        howTo.gameObject.SetActive(false);
        howToPlay.gameObject.SetActive(true);
        howToPlayImage.gameObject.SetActive(true);

    }
}

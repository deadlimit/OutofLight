using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public Image fadeImage;
    public Button newGame, options, exitGame, returnToMenu, howTo, next;
    public Slider volumeController;
    public FloatVariable volumeVar;
    public IntVariable darkSteps;
    public TransitInfo transitInfo;
    public SpawnPosition spawn;
    public List<BoolVariable> progression = new List<BoolVariable>();
    public Journal journal;
    public GameObject buttonP, howToPlayPanel, howF, howS, howH, howD;

    private void Awake()
    {
        try {

            foreach (var e in progression) {
                e.ChangeValue(false);
            }

            journal.journal.Clear();

        }
        catch (NullReferenceException e) {
            print(e);
        }
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
        howToPlayPanel.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
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
        howTo.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(true);
        howToPlayPanel.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
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
        howTo.gameObject.SetActive(true);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void HowToPlay()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(true);
        howTo.gameObject.SetActive(false);
    }

    public void NextButton()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        
        howF.gameObject.SetActive(true);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void NextButton2()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(true);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void NextButton3()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(true);
        howD.gameObject.SetActive(false);
    }

    public void NextButton4()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(true);
    }

    public void NextButton5()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        
        howToPlayPanel.SetActive(true);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void BackButton()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(true);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void BackButton2()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(true);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void BackButton3()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(true);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(false);
    }

    public void BackButton4()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(true);
        howD.gameObject.SetActive(false);
    }

    public void BackButton5()
    {
        newGame.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        returnToMenu.gameObject.SetActive(false);
        volumeController.gameObject.SetActive(false);
        howToPlayPanel.SetActive(false);
        howTo.gameObject.SetActive(false);
        howF.gameObject.SetActive(false);
        howS.gameObject.SetActive(false);
        howH.gameObject.SetActive(false);
        howD.gameObject.SetActive(true);
    }
}

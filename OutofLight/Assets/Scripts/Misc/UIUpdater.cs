using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIUpdater : MonoBehaviour {

    public Text roomText;
    public GameState gameState;
    public IntVariable steps, darkSteps;
    public Image fadeImage;
    public GameObject interactB;

    private void Start() {
        fadeImage.enabled = true;
        fadeImage.CrossFadeAlpha(0.1f, 3f, false);
        interactB = GameObject.Find("InteractButton");
        interactB.gameObject.SetActive(false);
        roomText.enabled = true;
    }

    private void Update() {
        DisplayScene();
    }

    private void DisplayScene()
    {
        roomText.text = SceneManager.GetActiveScene().name;
        roomText.CrossFadeAlpha(0.1f, 5f, false);
    }

    

}

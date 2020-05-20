﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UINewRoom : MonoBehaviour {
    
    public Image fadeImage;
    public Text room;
    public Image presenterbg;
    public RoomColors roomColors;
    
    public float fadeTime;
    public float waitBeforeTextFade;

    private void Start() {
        room.text = SceneManager.GetActiveScene().name;
        fadeImage.enabled = true;
        StartCoroutine(ShowSequence());
    }

    private IEnumerator ShowSequence() {
        try {
            room.color = roomColors.roomColors[SceneManager.GetActiveScene().name];
        }
        catch (KeyNotFoundException e) {
            
        }

        StartCoroutine(ImageFade(0, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        StartCoroutine(SceneText(1, fadeTime));
        yield return new WaitForSeconds(fadeTime + waitBeforeTextFade);
        StartCoroutine(SceneText(0, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        Destroy(gameObject);
    }
    
    private IEnumerator ImageFade(float value, float time) {
        var alpha = fadeImage.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            var newColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,
                Mathf.Lerp(alpha, value, t));
            fadeImage.color = newColor;
            yield return null;
        }
    }
    
    private IEnumerator SceneText(float value, float time) {
        var alpha = room.color.a;
        var alpha2 = presenterbg.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            var newColor = new Color(room.color.r, room.color.g, room.color.b,
                Mathf.Lerp(alpha, value, t));
            room.color = newColor;
            presenterbg.color = newColor;
            yield return null;
        }
        yield return new WaitForSeconds(waitBeforeTextFade);
    }
    
}

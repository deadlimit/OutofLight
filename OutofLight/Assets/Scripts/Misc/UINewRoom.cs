using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UINewRoom : MonoBehaviour {
    
    public Image fadeImage;
    public Text room;

    public float fadeTime;
    public float waitBeforeTextFade;

    private void Start() {
        room.text = SceneManager.GetActiveScene().name;
        fadeImage.enabled = true;
        StartCoroutine(ShowSequence());

    }

    private IEnumerator ShowSequence() {
        Debug.Log("Fade image");
        StartCoroutine(ImageFade(0, fadeTime));
        yield return new WaitForSeconds(fadeTime);
        Debug.Log("Fade in Text");
        StartCoroutine(SceneText(1, fadeTime));
        yield return new WaitForSeconds(fadeTime + waitBeforeTextFade);
        Debug.Log("Fade out Text");
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
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            var newColor = new Color(room.color.r, room.color.g, room.color.b,
                Mathf.Lerp(alpha, value, t));
            room.color = newColor;
            yield return null;
        }
        yield return new WaitForSeconds(waitBeforeTextFade);
    }
    
}

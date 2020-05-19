using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UINewRoom : MonoBehaviour {
    
    public Image fadeImage;
    public GameObject roomPresenter;
    private void Start() {
        fadeImage.enabled = true;
        StartCoroutine(FadeTo(0, 2));
    }
    
    private IEnumerator FadeTo(float value, float time) {
        var alpha = fadeImage.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
            var newColor = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b,
                Mathf.Lerp(alpha, value, t));
            fadeImage.color = newColor;
            yield return null;
        }
        
        Instantiate(roomPresenter, transform.position + (Vector3.up * 100) , Quaternion.identity, transform);
    }
    
}

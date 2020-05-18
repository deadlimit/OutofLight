using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomPresenter : MonoBehaviour {

	
	public Text sceneName;
	
	private void Awake() {
		sceneName.text = SceneManager.GetActiveScene().name;
		StartCoroutine(FadeTo(255, 2));
	}

	private void Start() {
		StartCoroutine(FadeTo(0, 3));
	}
	

	private IEnumerator FadeTo(float value, float time) {
		var alpha = sceneName.color.a;
		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
			var newColor = new Color(sceneName.color.r, sceneName.color.g, sceneName.color.b,
				Mathf.Lerp(alpha, value, t));
			sceneName.color = newColor;
			yield return null;
		}
	}
}

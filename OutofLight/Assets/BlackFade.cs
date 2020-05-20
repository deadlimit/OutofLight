using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour {

	public Image image;
	public GameEvent BlackFadeDone;
	public float seconds;
	private void Awake() {
		StartCoroutine(Fade());
	}

	private IEnumerator Fade() {
		StartCoroutine(ImageFade(1, seconds));
		yield return new WaitForSeconds(seconds * 2);
		StartCoroutine(ImageFade(0, seconds));
		BlackFadeDone.Raise();

	}
	

	private IEnumerator ImageFade(float value, float time) {
		var alpha = image.color.a;
		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
			var newColor = new Color(image.color.r, image.color.g, image.color.b,
				Mathf.Lerp(alpha, value, t));
			image.color = newColor;
			yield return null;
		}
	}

}

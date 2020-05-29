using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequirementText : MonoBehaviour {

	public float fadeInTime, fadeOutTime;
	public float yDirection;
	
	private TextMesh text;
	private Vector3 originalPosition;

	private void Awake() {
		text = GetComponentInChildren<TextMesh>();
		originalPosition = transform.position;
	}

	public void MoveAndShowText() {
		StartCoroutine(ShowText());
		LeanTween.moveY(gameObject, yDirection, 3);

	}
	public void SetText(string text) {
		this.text.text = text;
	}
	
	private IEnumerator ShowText() {
		StartCoroutine(TextFade(1, fadeInTime));
		yield return new WaitForSeconds(2);
		StartCoroutine(TextFade(-1, fadeOutTime));
		yield return new WaitForSeconds(1.2f);
		transform.position = originalPosition;
	}
	
	private IEnumerator TextFade(float value, float time) {
		var alpha = text.color.a;
		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
			var newColor = new Color(text.color.r, text.color.g, text.color.b,
				Mathf.Lerp(alpha, value, t));
			text.color = newColor;
			yield return null;
		}
	}
	
	
	
}

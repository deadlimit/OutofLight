using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;
using UnityEngine.UI;

public class StairDirection : MonoBehaviour {

	public TransitInfo rightPosition;
	public TransitInfo leftPosition;
	public TransitInfo downPosition;

	public Button right;
	public Button left;
	public Button down;

	private Stair stair;
	
	public void Awake() {
		stair = GameObject.FindGameObjectWithTag("Stair").gameObject.GetComponent<Stair>();
		StartCoroutine(ImageFade(1, 2, false));
	}

	public void MoveLeft() {
		StartCoroutine(stair.MoveUp(leftPosition.otherSide));
		StartCoroutine(ImageFade(0, 1, true));
		CameraController.instance.ActivateLeftBalconyCamera();
	}
	public void MoveRight() {
		StartCoroutine(stair.MoveUp(rightPosition.otherSide));
		StartCoroutine(ImageFade(0, 1, true));
		CameraController.instance.ActiveRightBalconyCamera();
	}
	public void MoveDown() {
		StartCoroutine(stair.MoveUp(downPosition.otherSide));
		StartCoroutine(ImageFade(0,1 , true));
		CameraController.instance.ActivateMainCamera();
	}

	public void FadeAwayTemporary() {
		StartCoroutine(ImageFade(0, .1f, false));
	}

	private IEnumerator ImageFade(float value, float time, bool destroy) {
		if(!destroy)
			yield return new WaitForSeconds(2);
		
		var alpha = right.colors.normalColor.a;
		for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / time) {
			var newColor = new Color(right.colors.normalColor.r, right.colors.normalColor.g, right.colors.normalColor.b,
				Mathf.Lerp(alpha, value, t));
			ColorBlock color = right.colors;
			color.normalColor = newColor;
			color.highlightedColor = newColor;
			color.selectedColor = newColor;
			right.colors = color;
			left.colors = color;
			down.colors = color;
			yield return null;
		}

		if(destroy)
			Destroy(gameObject, 1);
	}

}

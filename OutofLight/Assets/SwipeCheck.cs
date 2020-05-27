using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class SwipeCheck : MonoBehaviour {

	public RectTransform rect;


	private void Awake() {
		rect = GetComponent<RectTransform>();
		rect.sizeDelta = new Vector2(Screen.width - (Screen.width * .2f), Screen.height - (Screen.height * .2f));
		rect.anchoredPosition = rect.sizeDelta;
	}

}

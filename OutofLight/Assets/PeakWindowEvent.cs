using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class PeakWindowEvent : MonoBehaviour, IInteractable {

	public CinemachineVirtualCamera peakCamera;
	public Button button;
	public Material ghostShader;
	public GameObject ghostFlame;

	public float shaderSpeed;
	public float waitBeforeShowingGhost;

	public AudioSource audio;
	
	private void Awake() {
		ghostFlame.gameObject.SetActive(false);
		peakCamera.gameObject.SetActive(false);
		StartCoroutine(ChangeShader(3));
	}
	
	public void Use() {
		StartCoroutine(PeakSequence());
	}

	private IEnumerator PeakSequence() {
		peakCamera.gameObject.SetActive(true);
		yield return new WaitForSeconds(waitBeforeShowingGhost);
		StartCoroutine(ChangeShader(-3));
		yield return new WaitForSeconds(.3f);
		audio.Play();
		yield return new WaitForSeconds(1);
		StartCoroutine(ChangeShader(3));
		peakCamera.gameObject.SetActive(false);
	}
	
	public string GetPrompt() {
		return "Peak inside";
	}

	public Button CustomSprite() {
		return button;
	}
	
	private IEnumerator ChangeShader(int value) {
		float start = 0;
		float end = 1;
		while (start < end) {
			float changeValue = Mathf.Lerp(ghostShader.GetFloat("ShaderController"), value, Time.deltaTime * shaderSpeed);
			ghostShader.SetFloat("ShaderController", changeValue);
			start += Time.deltaTime;
			yield return null;
		}
	}
}

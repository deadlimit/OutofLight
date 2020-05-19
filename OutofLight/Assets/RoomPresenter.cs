using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoomPresenter : MonoBehaviour {

	
	public Text sceneName;
	
	private void Awake() {
		sceneName.text = SceneManager.GetActiveScene().name;
		
	}

	private void Start() {
		
		
	}
	
	

}

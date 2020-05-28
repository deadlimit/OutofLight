using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
[CreateAssetMenu]
public class SoundDictionary : ScriptableObject {
	
	public List<MaterialList> materials = new List<MaterialList>();
	
	public Dictionary<MaterialList, AudioClip> soundLibrary = new Dictionary<MaterialList, AudioClip>();

	public void Awake() {
		foreach(var materialList in materials)
			soundLibrary.Add(materialList, materialList.assosiatedSound);
	}
	
	public AudioClip GetAudioClip(Material material) {
		foreach(var key in materials)
			if (key.ContainsMaterial(material))
				return soundLibrary[key];

		
		Debug.Log("IN looop");
		return null;
	}

}



using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SoundDictionary : ScriptableObject {
	
	public List<MaterialList> materials = new List<MaterialList>();
	
	public Dictionary<MaterialList, AudioClip> soundLibrary = new Dictionary<MaterialList, AudioClip>();

	public void OnEnable() {
		foreach (var materialList in materials) {
			if(!soundLibrary.ContainsKey(materialList))
				soundLibrary.Add(materialList, materialList.assosiatedSound);
		}
			
	}
	
	public AudioClip GetAudioClip(Material material) {
		foreach(var key in materials)
			if (key.ContainsMaterial(material))
				return soundLibrary[key];

		return null;
	}
	
}



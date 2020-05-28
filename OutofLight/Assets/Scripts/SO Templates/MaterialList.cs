using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MaterialList : ScriptableObject {
	public List<Material> materials = new List<Material>();
	public AudioClip assosiatedSound;

	public bool ContainsMaterial(Material material) {
		Debug.Log(materials.Contains(material));
		return materials.Contains(material);
	}
}
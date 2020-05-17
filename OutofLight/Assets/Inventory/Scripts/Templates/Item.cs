using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 2)]
public class Item : ScriptableObject {

    public string name;
    public string description;
    public Image image;

}

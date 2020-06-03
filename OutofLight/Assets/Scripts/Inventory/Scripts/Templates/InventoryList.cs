using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "InventoryList", menuName = "Inventory/InventoryList", order = 1)]
public class InventoryList : ScriptableObject {

    public List<Item> items = new List<Item>();
}

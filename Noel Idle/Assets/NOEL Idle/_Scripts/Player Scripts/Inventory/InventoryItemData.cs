using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string TypeOfItem;
    public string id;
    public string displayNAME;
    public Sprite item_icon;

}

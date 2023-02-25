using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class ItemProperties : ScriptableObject
{
    public string itemName;
    public string desc;
    public Sprite icon;
}

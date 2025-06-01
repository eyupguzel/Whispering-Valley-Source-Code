using System;
using UnityEngine;

public enum ItemType { Seed, Tool, Food, Material }
[CreateAssetMenu(menuName = "Inventory/Item")]
[Serializable]
public class Item : ScriptableObject
{
    public string itemName;
    public bool isStackable;
    public Sprite icon;
    public int maxStackSize;
    public ItemType itemType;
}

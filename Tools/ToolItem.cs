using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Tool Item")]
public abstract class ToolItem : Item, ITool
{
    public abstract void Use(SoilData soil, Vector3Int cellPosition);
}

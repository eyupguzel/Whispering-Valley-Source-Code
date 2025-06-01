using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/SeedTool")]

public class SeedsToolItem : Item, ISeedTool
{
    public CropData cropData;
    public void Use(SoilData soil, Vector3Int cellPosition)
    {
        soil.isPlanted = true;
    }
}

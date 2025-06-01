using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Tools/Watering")]
public class Watering : ToolItem
{
    public override void Use(SoilData soil, Vector3Int cellPosition)
    {
        if (soil != null)
        {
            AnimationController.Instance.SetAnimationStrategy(new WateringAnimation());
            soil.isWatered = true;
        }
    }
}

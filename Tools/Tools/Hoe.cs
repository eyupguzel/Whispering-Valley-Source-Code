using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/Tools/Hoe")]
public class Hoe : ToolItem
{
    public override void Use(SoilData soil, Vector3Int cellPosition)
    {
        if (soil != null)
        {
            AnimationController.Instance.SetAnimationStrategy(new HoeingAnimation());
            soil.isTilled = true;
        }
    }
}

using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Tree Tools/Axeing")]
public class Axeing : TreeToollItem
{
    public override void Use(BaseTree tree)
    {
        tree.Chop();
    }
}

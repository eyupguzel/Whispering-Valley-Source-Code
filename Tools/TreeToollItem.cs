using UnityEngine;
[CreateAssetMenu(menuName = "Inventory/TreeTool")]
public abstract class TreeToollItem : Item, ITreeTool
{
    public abstract void Use(BaseTree tree);
}

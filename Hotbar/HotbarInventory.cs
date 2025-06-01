using UnityEngine;

public class HotbarInventory : MonoBehaviour, IInventoryOwner
{
    public InventoryService InventoryService { get; private set; } = new(8);
}

using UnityEngine;

public class PlayerInventory : MonoBehaviour, IInventoryOwner
{
    public InventoryService InventoryService { get; private set; } = new(10);
}

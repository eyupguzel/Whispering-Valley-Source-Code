using UnityEngine;

public class ChestInventory : MonoBehaviour,IChestInventoryOwner
{
    public ChestService ChestService { get; private set; } = new(10);
}

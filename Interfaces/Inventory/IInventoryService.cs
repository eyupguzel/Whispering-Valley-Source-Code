using System.Collections.Generic;
using UnityEngine;

public interface IInventoryService
{
    public bool MoveItem(InventorySlot sourceSlot, InventorySlot targetSlot, int quantity);
    public bool AddItem(Item item, int quantity);
    public bool RemoveItem(Item item, int quantity);
    public bool HasItem(Item item, int quantity);
    IReadOnlyList<InventorySlot> GetAllSlots();
}

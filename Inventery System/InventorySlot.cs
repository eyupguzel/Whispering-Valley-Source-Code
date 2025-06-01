using System;
using UnityEngine;

public class InventorySlot
{
    public Item Item { get; set; }
    public int Quantity { get; private set; }

    public int maxStackSize = 64;
    public bool IsEmpty => Item == null;

    public void SetItem(Item item, int quantity)
    {
        Item = item;
        Quantity = quantity;
    }
    public void AddQuantity(int quantity)
    {
        Quantity += quantity;
    }
    public void RemoveQuantity(int quantity)
    {
        Quantity -= quantity;
        if (Quantity <= 0)
        {
            Item = null;
            Quantity = 0;
        }
    }
    public void Clear()
    {
        Item = null;
        Quantity = 0;
    }
}

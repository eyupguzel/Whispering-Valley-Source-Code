using System.Collections.Generic;
using System;
using UnityEngine;

public class ChestService : IInventoryService
{
    private List<InventorySlot> slots;
    private int capacity;
    public ChestService(int capacity)
    {
        this.capacity = capacity;
        slots = new List<InventorySlot>(this.capacity);

        for (int i = 0; i < capacity; i++)
            slots.Add(new InventorySlot());
    }
    public bool MoveItem(InventorySlot sourceSlot, InventorySlot targetSlot, int quantity)
    {
        if (targetSlot != sourceSlot)
        {
            // Hedef slot’a ekleme yapýlabilir mi kontrol et
            if (targetSlot.IsEmpty || (targetSlot.Item == sourceSlot.Item && targetSlot.Item.isStackable))
            {
                int maxAddable = targetSlot.Item?.isStackable == true ? targetSlot.maxStackSize - targetSlot.Quantity : 0;
                if (targetSlot.IsEmpty || quantity <= maxAddable)
                {
                    // Kaynak slot’tan çýkar
                    sourceSlot.AddQuantity(-quantity);
                    if (sourceSlot.Quantity <= 0)
                        sourceSlot.Clear();

                    // Hedef slot’a ekle
                    targetSlot.SetItem(sourceSlot.Item, targetSlot.Quantity + quantity);

                    InventoryEventSystem.NotifyChestInventoryChanged();
                    return true;
                }
            }
            return false;
        }
        return false;
    }
    public bool AddItem(Item item, int quantity)
    {
        if (item.isStackable)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.Item == item && quantity < slot.Quantity)
                {
                    slot.AddQuantity(quantity);
                    InventoryEventSystem.NotifyChestInventoryChanged();
                    return true;
                }
            }
        }
        foreach (InventorySlot slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item, quantity); 
                InventoryEventSystem.NotifyChestInventoryChanged();
                return true;
            }
        }
        return false;
    }
    public bool HasItem(Item item, int quantity)
    {
        int total = 0;
        foreach (var slot in slots)
        {
            if (slot.Item == item)
                total += slot.Quantity;
        }
        return total >= quantity;
    }

    public bool RemoveItem(Item item, int quantity)
    {
        foreach (InventorySlot slot in slots)
        {
            if (slot.Item == item && slot.Quantity >= quantity)
            {
                slot.RemoveQuantity(quantity);
                if (slot.Quantity <= 0)
                {
                    slot.Clear();
                }
                InventoryEventSystem.NotifyChestInventoryChanged();
                return true;
            }
        }
        return false;
    }
    public IReadOnlyList<InventorySlot> GetAllSlots() => slots.AsReadOnly();

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryService : IInventoryService
{
    private List<InventorySlot> slots;
    
    private int capacity;

    public InventoryService(int capacity)
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
            if (targetSlot.IsEmpty || (targetSlot.Item == sourceSlot.Item && targetSlot.Item.isStackable))
            {
                int maxAddable = targetSlot.Item?.isStackable == true ? targetSlot.maxStackSize - targetSlot.Quantity : 0;
                if (targetSlot.IsEmpty || quantity <= maxAddable)
                {
                    Item movedItem = sourceSlot.Item; //  Bunu sakla

                    sourceSlot.AddQuantity(-quantity);
                    if (sourceSlot.Quantity <= 0)
                        sourceSlot.Clear();

                    targetSlot.SetItem(movedItem, targetSlot.Quantity + quantity); //  movedItem kullan
                    InventoryEventSystem.NotifyInventoryChanged();
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
                if (slot.Item == item && slot.Quantity < item.maxStackSize)
                {
                    int availableSpace = item.maxStackSize - slot.Quantity;
                    int toAdd = Math.Min(quantity, availableSpace);
                    slot.AddQuantity(toAdd);
                    InventoryEventSystem.NotifyInventoryChanged();
                    return true;
                }
            }
        }
        // Boþ slot’a ekleme mantýðý ayný kalabilir
        foreach (var slot in slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetItem(item, quantity);
                InventoryEventSystem.NotifyInventoryChanged();
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(Item item, int quantity)
    {
        foreach (var slot in slots)
        {
            if (slot.Item == item && slot.Quantity >= quantity)
            {
                slot.AddQuantity(-quantity);
                if (slot.Quantity <= 0)
                {
                    slot.Clear();
                    InventoryEventSystem.NotifyInventoryChanged();
                    return true;
                }
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


    public IReadOnlyList<InventorySlot> GetAllSlots() => slots.AsReadOnly();

    public List<InventorySlot> GetHotbarSlots(int count = 8)
    {
        return slots.Take(count).ToList();
    }
}

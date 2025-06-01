using System;
using UnityEngine;

public static class InventoryEventSystem
{
    public static event Action OnInventoryChanged;
    public static event Action OnChestInventoryChanged;

    public static void NotifyInventoryChanged()
    {
        OnInventoryChanged?.Invoke();
    }
    public static void NotifyChestInventoryChanged()
    {
       OnChestInventoryChanged?.Invoke();
    }
}

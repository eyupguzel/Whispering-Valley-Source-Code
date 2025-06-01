using UnityEngine;

public class HotbarUI : MonoBehaviour
{
    public InventorySlotUI[] hotbarSlots;
    public InventoryService inventoryService;
    private void Awake()
    {
        hotbarSlots = GetComponentsInChildren<InventorySlotUI>();
    }
    public void Init(InventoryService inventoryService)
    {
        this.inventoryService = inventoryService;
        InventoryEventSystem.OnInventoryChanged += RefreshHotbar;
        InventoryEventSystem.OnChestInventoryChanged += RefreshHotbar;
        RefreshHotbar();
    }
    public void RefreshHotbar()
    {
        var slots = inventoryService.GetHotbarSlots();
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            if (i < slots.Count)
                hotbarSlots[i].Set(slots[i],inventoryService);
            else
                hotbarSlots[i].Clear();
        }
    }
}

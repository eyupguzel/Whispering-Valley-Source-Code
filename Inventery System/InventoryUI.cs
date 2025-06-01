using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public  InventorySlotUI[] slots;
    private InventoryService inventoryService;
    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlotUI>();
    }
    public void Init(InventoryService inventoryService)
    {
        this.inventoryService = inventoryService;
        InventoryEventSystem.OnInventoryChanged += RefreshUI;
        InventoryEventSystem.OnChestInventoryChanged += RefreshUI;
        RefreshUI();
    }

    public void RefreshUI()
    {
        var slot = inventoryService.GetAllSlots();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < slot.Count)
                slots[i].Set(slot[i],inventoryService);
            else
                slots[i].Clear();
        }
    }
}


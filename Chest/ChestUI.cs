using System.Linq;
using UnityEngine;

public class ChestUI : MonoBehaviour
{
    public InventorySlotUI[] slots;
    private ChestService chestService;
    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlotUI>(true);
    }
    public void Init(ChestService chestService)
    {
        this.chestService = chestService;
        InventoryEventSystem.OnChestInventoryChanged += RefreshUI;
        InventoryEventSystem.OnInventoryChanged += RefreshUI;
        RefreshUI();
    }

    public void RefreshUI()
    {
        var slot = chestService.GetAllSlots();

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < slot.Count && slot[i] != null)
                slots[i].Set(slot[i],null,chestService);
            else
                slots[i].Clear();
        }
    }
}
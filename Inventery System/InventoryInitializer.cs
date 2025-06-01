using UnityEngine;
using System.Linq;

public class InventoryInitializer : Singleton<InventoryInitializer>
{
    [SerializeField] private Item item_1;
    [SerializeField] private Item item_2;
    [SerializeField] private Item item_3;
    [SerializeField] private Item item_strawberry;

    private void Start()
    {
        var owners = FindObjectsByType<PlayerInventory>(FindObjectsSortMode.InstanceID);
        var chestOwners = FindObjectsByType<ChestInventory>(FindObjectsSortMode.InstanceID);

        if (chestOwners != null)
            foreach (var owner in chestOwners)
            {

                var serviceChest = owner.ChestService;
                serviceChest.AddItem(item_1, 1);
                if (owner is MonoBehaviour mono)
                {
                    ChestUI chest = mono.GetComponentInChildren<ChestUI>(true);
                    if (chest != null)
                        chest.Init(serviceChest);
                }
            }

        foreach (var owner in owners)
        {
            var service = owner.InventoryService;

            service.AddItem(item_1, 1);
            service.AddItem(item_2, 1);
            service.AddItem(item_3, 1);
            service.AddItem(item_strawberry, 1);

            if (owner is MonoBehaviour mono)
            {
                var ui = mono.GetComponentInChildren<InventoryUI>();
                if (ui != null)
                    ui.Init(service);
                var hotbar = mono.GetComponentInChildren<HotbarUI>();
                if (hotbar != null)
                    hotbar.Init(service);
            }
        }
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image icon;
    private TextMeshProUGUI quantityText;

    public InventorySlot slot;
    public Item item;
    public InventoryService inventoryService;
    public ChestService chestService;

    private void Start()
    {
        icon = transform.Find("item").GetComponent<Image>();
        quantityText = transform.Find("quantityText")?.GetComponent<TextMeshProUGUI>();
    }
    public void Set(InventorySlot slot, InventoryService inventoryService = null, ChestService chestService = null)
    {
        this.inventoryService = inventoryService;
        this.chestService = chestService;

        this.slot = slot;

        UpdateUI(slot);
    }

    private void UpdateUI(InventorySlot slot)
    {
        if (slot.IsEmpty)
        {
            transform.Find("item").GetComponent<Image>().enabled = false;
            // if(quantityText != null)
            //     transform.Find("quantityText").GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            if (transform.Find("item").GetComponent<Image>() != null)
            {
                item = slot.Item;
                transform.Find("item").GetComponent<Image>().sprite = slot.Item.icon;
                // if(quantityText != null)
                //     transform.Find("quantityText").GetComponent<TextMeshProUGUI>().text = slot.Quantity >= 1 ? $"{slot.Quantity}" : "";
                transform.Find("item").GetComponent<Image>().enabled = true;
            }
            else
                Debug.Log("Icon is null" + "  " + gameObject.name);
        }
    }

    public void Set(Item item)
    {
        if (item != null)
        {
            icon.enabled = true;
            icon.sprite = item.icon;
            slot.Item = item;
        }
        else
            Debug.Log("Item is null");
    }
    public void Clear()
    {
        transform.Find("item").GetComponent<Image>().enabled = false;
        slot = null;
        item = null;
        // if(quantityText != null)
        //     transform.Find("quantityText").GetComponent<TextMeshProUGUI>().text = "";
    }
    bool inventoryServicesuccess = false;
    bool chestServicesuccess = false;
    public void OnDrop(PointerEventData eventData)
    {
        var dragged = DragHandler.currentDraggedItem;

        if (dragged != null && dragged.item != null)
        {
            if (slot != null)
            {
                if (inventoryService != null)
                {
                    inventoryServicesuccess = inventoryService.MoveItem(dragged.inventorySlot, slot, 1);
                    chestServicesuccess = false;
                }
                else if (chestService != null)
                {
                    chestServicesuccess = chestService.MoveItem(dragged.inventorySlot, slot, 1);
                    inventoryServicesuccess = false;
                }
                else
                {
                    inventoryServicesuccess = false;
                    chestServicesuccess = false;
                }
                if (inventoryServicesuccess || chestServicesuccess)
                {
                    dragged.wasDroppedOnValidSlot = true;
                    Set(dragged.item);
                   // UpdateUI(slot);
                }
                else
                {
                    Debug.Log("Item could not be moved to this slot");
                }
            }
        }
        else
        {
            Debug.Log("Dragged item is null");
        }
    }
}

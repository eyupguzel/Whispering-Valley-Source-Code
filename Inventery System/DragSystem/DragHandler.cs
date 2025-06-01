using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static DragHandler currentDraggedItem;
    public Item item;
    public int amount;
    private InventorySlotUI slotUI;

    private GameObject icon;
    private Image dragImage;

    public InventorySlot inventorySlot;
    public bool wasDroppedOnValidSlot;

    private void Start()
    {
        slotUI = GetComponent<InventorySlotUI>();
        icon = transform.Find("item").gameObject;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        inventorySlot = GetComponent<InventorySlotUI>().slot;
        item = GetComponent<InventorySlotUI>().slot.Item;
        wasDroppedOnValidSlot = false;
        if (item != null)
        {
            currentDraggedItem = this;
            Canvas canvas = new GameObject("CanvasDragImager").AddComponent<Canvas>();
            canvas.overrideSorting = true;
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 102;
            dragImage = new GameObject("DragImage").AddComponent<Image>();
            dragImage.transform.SetParent(canvas.transform);
            dragImage.sprite = item.icon;
            dragImage.raycastTarget = false;
        }
        else
            Debug.Log("Item is null");
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            dragImage.transform.position = eventData.position;
            icon.SetActive(false);
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            Destroy(dragImage.gameObject);
            Destroy(dragImage.transform.parent.gameObject);
            currentDraggedItem = null;

            if (wasDroppedOnValidSlot)
            {
                item = null;
                //slotUI.Clear(); // UI’ý güncelle
            }

            icon.SetActive(true);
        }
    }
}

using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    private Transform inventoryPanel;
    private bool isOpen;

    private void OnEnable()
    {
        UIEvents.OnInventoryOpenRequest += OpenInventory;
        UIEvents.OnInventoryCloseRequest += CloseInventory;
    }
    private void Start()
    {
        inventoryPanel = transform.Find("inventoryPanel");
        inventoryPanel.gameObject.SetActive(false);
        isOpen = inventoryPanel.gameObject.activeSelf;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isOpen)
                OpenInventory();
            else
                CloseInventory();
        }
    }
    private void OpenInventory()
    {
        inventoryPanel.gameObject.SetActive(true);
        isOpen = true;
    }
    private void CloseInventory()
    {
        inventoryPanel.gameObject.SetActive(false);
        //UIEvents.RequestChestClose();
        isOpen = false;
    }
}

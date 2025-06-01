using System;
using UnityEngine;

public class ChestControl : Singleton<ChestControl>
{
    private GameObject canvas;
    private bool isOpen;

    private void OnEnable()
    {
        UIEvents.OnChestCloseRequest += CloseChest;
        canvas = transform.Find("Canvas").gameObject;
        canvas.SetActive(false);
    }
    private void OnDisable() => UIEvents.OnChestCloseRequest -= CloseChest;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D hitCollider = Physics2D.OverlapBox(transform.position, Vector2.one, 1f);
            PlayerController player = hitCollider.GetComponent<PlayerController>();
            if (player != null && !isOpen)
            {
                UIEvents.RequestInventoryOpen();
                canvas.gameObject.SetActive(true);
                isOpen = true;
            }
            else if (player != null && isOpen)
                CloseChest();
        }
    }
    private void CloseChest()
    {
        UIEvents.RequestInventoryClose();
        canvas.gameObject.SetActive(false);
        isOpen = false;
    }
}

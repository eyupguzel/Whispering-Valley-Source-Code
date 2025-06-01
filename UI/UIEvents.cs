using System;

public static class UIEvents
{
    public static event Action OnInventoryOpenRequest;
    public static event Action OnInventoryCloseRequest;

    public static event Action OnChestCloseRequest;

    public static void RequestInventoryOpen()
    {
        OnInventoryOpenRequest?.Invoke();
    }
    public static void RequestInventoryClose()
    {
        OnInventoryCloseRequest?.Invoke();
    }
    public static void RequestChestClose()
    {
        OnChestCloseRequest?.Invoke();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ToolbarManager : MonoBehaviour
{
    [SerializeField] private ToolIndicator toolIndicator;
    private Button interactiveButton;
    private InventorySlotUI slotUI;

    private void Start()
    {
        slotUI = GetComponent<InventorySlotUI>();
        interactiveButton = GetComponent<Button>();
        interactiveButton.onClick.AddListener(() =>
        {
            OnClick();
        });
    }
    private void OnClick()
    {
        Item currentItem = slotUI.item;
        if (currentItem is ITool tool)
        {
            toolIndicator.SetTool(currentItem);
            return;
        }
        else
            toolIndicator.SetTool(null);

        if (currentItem is ITreeTool treeTool)
        {
            toolIndicator.SetTool(currentItem);
            return;
        }
        else
            toolIndicator.SetTool(null);

        if (currentItem is ISeedTool seedTool)
        {
            toolIndicator.SetTool(currentItem);
            Debug.Log("Setting seed tool");
            return;
        }
        else
            toolIndicator.SetTool(null);
    }
}

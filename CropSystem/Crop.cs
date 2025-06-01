/*using UnityEngine;

public class Crop : MonoBehaviour
{
    public CropData cropData;
    private int currentStageIndex;
    private int growthTimer;

    private bool isWateredToday;

    private SpriteRenderer spriteRenderer;

    private IEventBinding<DayPassedEvent> dayBinding;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    public void Init()
    {
        gameObject.SetActive(true);
        dayBinding = new EventBinding<DayPassedEvent>(Grow);

        EventBus<DayPassedEvent>.Subscribe(dayBinding);
        UpdateVisual();
    }
    private void Grow()
    {
        if (currentStageIndex >= cropData.cropStages.Length - 1)
            return;

        growthTimer++;
        if (growthTimer >= cropData.cropStages[currentStageIndex].growthTime)
        {
            growthTimer = 0;
            currentStageIndex++;
            UpdateVisual();
        }

    }
    private void UpdateVisual()
    {
        spriteRenderer.sprite = cropData.cropStages[currentStageIndex].sprite;
    }
    private bool IsHarvestable()
    {
        return cropData.cropStages[currentStageIndex].isHarvestable;
    }
}
*/
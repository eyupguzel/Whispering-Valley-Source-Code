using UnityEngine;

public class SoilDayUpdater
{
    private SoilService soilService;

    private EventBinding<DayPassedEvent> newDayBinding;
    public SoilDayUpdater(SoilService soilService)
    {
        newDayBinding = new EventBinding<DayPassedEvent>(OnNewDay);
        EventBus<DayPassedEvent>.Subscribe(newDayBinding);

        this.soilService = soilService;
    }

    private void OnNewDay()
    {
        soilService.RefreshPlantVisuals();
        var allSoilData = soilService.GetAllSoilData();
        foreach (var kvp in allSoilData)
        {
            var pos = kvp.Key;
            var data = kvp.Value;

            if(data.isWatered)
                data.isWatered = false;
        }
        soilService.RefreshSoilVisuals();
    }
}

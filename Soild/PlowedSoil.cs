using UnityEngine;

public class WetSoil : ISoilState// Islak toprak
{
    private Soil soil;
    public void Enter(Soil soilManager)
    {
        soil = soilManager;
        soil.Moisture = 0.5f;
        soil.Nutrients = 0.5f;
        soil.UpdateVisual();
    }

    public void Fertilize(float fertilizerQuality)
    {
        soil.Nutrients += fertilizerQuality;
    }

    public void Water()
    {
        soil.Moisture += 0.5f;
        Debug.Log("Toprak sulandý.");
    }
    public void Update()
    {

    }

    public void Arable()
    {
        Debug.Log("Toprak ekilebilir hale geldi.");
    }
}

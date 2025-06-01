using UnityEngine;

public class BarrenSoil : ISoilState // Kuru Toprak
{
    private Soil soil;

    public void Enter(Soil soilManager)
    {
        soil = soilManager;
        soil.Moisture = 0.2f;
        soil.UpdateVisual();
    }

    public void Water()
    {
        soil.Moisture += 0.5f;
    }

    public void Update()
    {
        if (soil.Moisture > 0.3f)
        {
            soil.ChangeState(new WetSoil());
        }
    }

    public void Fertilize(float fertilizerQuality)
    {
        soil.Nutrients += fertilizerQuality;
    }
    public void Arable()
    {
        throw new System.NotImplementedException();
    }
}

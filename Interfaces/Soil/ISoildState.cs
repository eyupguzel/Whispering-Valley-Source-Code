using UnityEngine;

public interface ISoilState
{
    void Enter(Soil soil);
    void Update();
    void Water();
    void Fertilize(float fertilizerQuality);
    void Arable();
}

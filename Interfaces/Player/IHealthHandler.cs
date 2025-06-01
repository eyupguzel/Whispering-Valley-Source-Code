using UnityEngine;

public interface IHealthHandler
{
    int CurrentHealth { get; }
    void AddHealth(int amount);
    void SubtractHealth(int amount);
}

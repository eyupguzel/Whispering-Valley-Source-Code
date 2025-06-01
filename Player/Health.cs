using UnityEngine;

public class Health : IHealthHandler
{
    public int MaxHealth { get; private set; } = 100;
    public int CurrentHealth { get; private set; } = 100;
    public void AddHealth(int amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }

    public void SubtractHealth(int amount)
    {
        CurrentHealth -= amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
}

using UnityEngine;

public class PlayerStats
{
    private IMoneyHandler moneyHandler;
    private IHealthHandler healthHandler;

    public PlayerStats(IMoneyHandler moneyHandler, IHealthHandler healthHandler)
    {
        this.moneyHandler = moneyHandler;
        this.healthHandler = healthHandler;
    }

    public void EarnMoney(int amount)
    {
        moneyHandler.AddMoney(amount);
    }
    public void SpendMoney(int amount)
    {
        moneyHandler.SubtractMoney(amount);
    }
    public void Heal(int amount)
    {
        healthHandler.AddHealth(amount);
    }
    public void TakeDamage(int amount)
    {
        healthHandler.SubtractHealth(amount);
    }
}

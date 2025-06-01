using System;
using UnityEngine;

public class Money : IMoneyHandler
{
    public int CurrentMoney { get; private set; } = 100;
    public event Action<int> OnMoneyChanged;


    public void AddMoney(int amount)
    {
        CurrentMoney += amount;
        OnMoneyChanged?.Invoke(CurrentMoney);
    }

    public void SubtractMoney(int amount)
    {
        if (CurrentMoney >= amount)
        {
            CurrentMoney -= amount;
            OnMoneyChanged?.Invoke(CurrentMoney);
        }
        else
            Debug.Log("Not enough money!");
    }
}

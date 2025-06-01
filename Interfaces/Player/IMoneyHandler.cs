using UnityEngine;

public interface IMoneyHandler
{
    int CurrentMoney { get; }
    void AddMoney(int amount);
    void SubtractMoney(int amount);
}

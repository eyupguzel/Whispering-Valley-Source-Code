using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    private TextMeshProUGUI moneyText;
    private Money money;
    public void Initialize(Money money)
    {
        this.money = money;
        money.OnMoneyChanged += UpdateMoneyText;
        UpdateMoneyText(money.CurrentMoney);
    }

    private void Start()
    {
        moneyText = transform.Find("moneyText").GetComponent<TextMeshProUGUI>();
    }
    private void UpdateMoneyText(int money)
    {
       // moneyText.text = money.ToString();
    }
}

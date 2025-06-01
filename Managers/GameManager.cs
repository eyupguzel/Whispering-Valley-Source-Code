using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private ChestUI[] chestUIs;
    [HideInInspector] public SleepService sleepService;

    public HotbarUI hotbarUI;
    [HideInInspector] public IInventoryService InventoryService { get;private set; }
    [HideInInspector] public IInventoryService chestService { get;private set; }
    [SerializeField] private Item item_1;
    [SerializeField] private Item item_2;

    private PlayerStats playerStats;
    [SerializeField] MoneyUI moneyUI;
    private void Start()
    {
        sleepService = GetComponent<SleepService>();

        Money money = new Money();
        Health health = new Health();
        playerStats = new PlayerStats(money, health);
        moneyUI.Initialize(money);

        /* InventoryService = new InventoryService(10);

         InventoryService.AddItem(item_1, 1);
         InventoryService.AddItem(item_1, 1);
         InventoryService.AddItem(item_2, 1);
         InventoryService.AddItem(item_1, 1);


         

         inventoryUI.Init((InventoryService)InventoryService);
         chestUIs[0].Init((ChestService)chestService);*/

        /*hotbarUI.Init((InventoryService)InventoryService);
        chestService = new ChestService(10);
        chestService.AddItem(item_1, 1);
        chestService.AddItem(item_2, 2);*/

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            playerStats.EarnMoney(100);
    }
}

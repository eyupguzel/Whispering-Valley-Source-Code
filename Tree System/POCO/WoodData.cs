using UnityEngine;

public class WoodData
{
    private WoodQuality woodQuality;
    private WoodType woodType;
    private int value;
    private int quantity;

    public WoodData(WoodQuality woodQuality, WoodType woodType, int value, int quantity)
    {
        this.woodQuality = woodQuality;
        this.woodType = woodType;
        this.value = value;
        this.quantity = quantity;
    }
}

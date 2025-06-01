using System;
using UnityEngine;

public enum CropSeason
{
    Summer,
    Fall,
    Winter,
    Spring
}
[CreateAssetMenu(fileName = "CropData", menuName = "Scriptable Objects/CropData")]
[Serializable]
public class CropData : ScriptableObject
{
    public string cropName;
    public int price;
    public int i;
    public CropStageData[] cropStages;
    public CropSeason[] cropSeason;

    public float excellentChance;
    public float goodChance;
    public float normalChance;
}

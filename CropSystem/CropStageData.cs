using UnityEngine;
using System;
using UnityEngine.Tilemaps;
[Serializable]
public class CropStageData
{
    public string stageName;
    public TileBase tile;
    public bool isHarvestable;
    public int growthTime;
}

using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Tilemaps;

[Serializable]
public class SoilService
{
    private SoilDayUpdater soilDayUpdater;
    private PlantDayUpdater plantDayUpdater;
    [SerializeField] private TileBase hoedSoilTile;
    [SerializeField] private TileBase wateredSoilTile;

    private Dictionary<Vector3Int, SoilData> soilDataMap = new();
    private Dictionary<Vector3Int, CropInstance> cropInstanceMap = new();

    private WaterTileMap waterTileMap;
    private PlantTileMap plantTileMap;
    public void Init()
    {
        soilDayUpdater = new(this);
        plantDayUpdater = new(this);
    }
    public void HoeSoil(Vector3Int pos, InteractionTilemapAccessor interactionTilemap)
    {
        if (!soilDataMap.ContainsKey(pos))
        {
            interactionTilemap.SetTile(pos, hoedSoilTile);
            soilDataMap[pos] = new SoilData();
        }
    }
    public void WaterSoil(Vector3Int pos, WaterTileMap waterTileMap)
    {
        this.waterTileMap = waterTileMap;
        if (soilDataMap.ContainsKey(pos))
        {
            waterTileMap.SetTile(pos, wateredSoilTile);
        }
    }
    public void PlantSoil(Vector3Int pos, PlantTileMap plantTileMap, CropData cropData)
    {
        this.plantTileMap = plantTileMap;
        if (soilDataMap.ContainsKey(pos) && plantTileMap.IsEmpty(pos))
        {
            var instance = new CropInstance
            {
                stageIndex = 0,
                cropData = cropData
            };
            cropInstanceMap[pos] = instance;
            plantTileMap.SetTile(pos, cropData.cropStages[0].tile);
        }
    }
    public void RefreshPlantVisuals()
    {
        foreach (var kvp in soilDataMap)
        {
            var pos = kvp.Key;
            var data = kvp.Value;

            if (!data.isWatered) continue;
            if (!cropInstanceMap.ContainsKey(pos)) continue;
            if (plantTileMap.GetTile(pos) == null) continue;

            var crop = cropInstanceMap[pos];
            crop.stageIndex++;
            int stageIndex = Mathf.Clamp(crop.stageIndex, 0, crop.cropData.cropStages.Length - 1);
            plantTileMap.SetTile(pos, crop.cropData.cropStages[stageIndex].tile);
        }
    }
    public void RefreshSoilVisuals()
    {
        foreach (var kvp in soilDataMap)
        {
            var pos = kvp.Key;
            var data = kvp.Value;

            if (!data.isWatered)
            {
                if (waterTileMap.GetTile(pos) != null)
                {
                    waterTileMap.SetTile(pos, null);
                }
            }
        }
    }
    public SoilData GetSoil(Vector3Int pos)
    {
        soilDataMap.TryGetValue(pos, out var data);
        return data;
    }
    public Dictionary<Vector3Int, SoilData> GetAllSoilData()
    {
        return soilDataMap;
    }
}

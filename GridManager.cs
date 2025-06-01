using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : Singleton<GridManager>
{
    [SerializeField] private BaseTilemapAccessor baseTilemap;
    [SerializeField] private InteractionTilemapAccessor interactionTilemap;
    [SerializeField] private WaterTileMap waterTileMap;
    [SerializeField] private PlantTileMap plantTileMap;
    [SerializeField] private HoeableTileCache hoeableTileCache;
    [SerializeField] private WaterableTileCache waterableTileCache;
    [SerializeField] private PlantableSoilCache plantableSoilCache;

    [SerializeField] private SoilService soilService;

    private void Start()
    {
        soilService.Init();
        hoeableTileCache.CacheHoeableTiles(baseTilemap);
    }

    public bool TryHoeTile(Vector3 worldPosition)
    {
        Vector3Int cellPos = baseTilemap.WorldToCell(worldPosition);

        if (hoeableTileCache.IsHoeable(cellPos) && interactionTilemap.IsEmpty(cellPos))
        {
            soilService.HoeSoil(cellPos, interactionTilemap);
            waterableTileCache.CacheWaterableTile(interactionTilemap);
            plantableSoilCache.CachePlantableSoil(interactionTilemap);
            return true;
        }
        return false;
    }
    public bool TryWaterTile(Vector3 worldPosition)
    {
        Vector3Int cellPos = baseTilemap.WorldToCell(worldPosition);
        if (waterableTileCache.IsWaterable(cellPos) && waterTileMap.IsEmpty(cellPos))
        {
            soilService.WaterSoil(cellPos, waterTileMap);
            return true;
        }
        return false;
    }
    public bool TryPlantSeed(Vector3 worldPosition, CropData cropData)
    {
        Vector3Int cellPos = baseTilemap.WorldToCell(worldPosition);
        if (plantableSoilCache.IsPlantable(cellPos) && plantTileMap.IsEmpty(cellPos))
        {
            Debug.Log("zort");
            soilService.PlantSoil(cellPos,plantTileMap, cropData);
            return true;
        }
        return false;
    }

    public Vector3Int WorldToCell(Vector3 worldPosition)
    {
        return baseTilemap.WorldToCell(worldPosition);
    }

    public SoilData GetSoilData(Vector3Int cellPos)
    {
        if (hoeableTileCache.IsHoeable(cellPos))
        {
            return soilService.GetSoil(cellPos);
        }
        return null;
    }
}

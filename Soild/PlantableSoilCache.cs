using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System;

[Serializable]
public class PlantableSoilCache
{
    [SerializeField] private TileBase[] plantableTiles;

    private static HashSet<Vector3Int> plantableSoilSet = new();

    public void CachePlantableSoil(InteractionTilemapAccessor tilemap)
    {
        var bounds = tilemap.GetBounds();
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);
                if (IsPlantableSoil(tile))
                {
                    plantableSoilSet.Add(pos);
                }
            }
        }
    }
    private bool IsPlantableSoil(TileBase tile)
    {
        foreach (var plantTileMap in plantableTiles)
        {
            if (tile == plantTileMap)
                return true;
        }
        return false;
    }
    public bool IsPlantable(Vector3Int pos) => plantableSoilSet.Contains(pos);
}

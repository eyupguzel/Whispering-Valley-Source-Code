using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

[Serializable]
public class WaterableTileCache
{
    [SerializeField] private TileBase[] waterableTiles;

    private static HashSet<Vector3Int> waterableTileSet = new();

    public void CacheWaterableTile(InteractionTilemapAccessor tilemap)
    {
        var bounds = tilemap.GetBounds();
        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);
                if (IsWaterableTile(tile))
                {
                    waterableTileSet.Add(pos);
                }
            }
        }
    }
    private bool IsWaterableTile(TileBase tile)
    {
        foreach (var waterable in waterableTiles)
        {
            if (tile == waterable)
                return true;
        }
        return false;
    }
    public bool IsWaterable(Vector3Int pos) => waterableTileSet.Contains(pos);
}

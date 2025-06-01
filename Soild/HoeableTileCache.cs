using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;
using System;

[Serializable]
public class HoeableTileCache
{
    [SerializeField] private TileBase[] hoeableTiles;

    private static HashSet<Vector3Int> hoeableTileSet = new();
    public void CacheHoeableTiles(BaseTilemapAccessor tilemap)
    {
        var bounds = tilemap.GetBounds();

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(pos);
                if (IsHoeableTile(tile))
                {
                    hoeableTileSet.Add(pos);
                }
            }
        }
    }

    private bool IsHoeableTile(TileBase tile)
    {
        foreach (var hoeable in hoeableTiles)
        {
            if (tile == hoeable)
                return true;
        }
        return false;
    }

    public bool IsHoeable(Vector3Int pos) => hoeableTileSet.Contains(pos);
}

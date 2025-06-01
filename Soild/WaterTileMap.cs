using UnityEngine.Tilemaps;
using UnityEngine;
using System;

[Serializable]
public class WaterTileMap
{
    [SerializeField] private Tilemap waterTile;

    public Vector3Int WorldToCell(Vector3 worldPos) => waterTile.WorldToCell(worldPos);

    public void SetTile(Vector3Int pos, TileBase tile) => waterTile.SetTile(pos, tile);
    public TileBase GetTile(Vector3Int pos) => waterTile.GetTile(pos);
    public BoundsInt GetBounds() => waterTile.cellBounds;
    public bool IsEmpty(Vector3Int pos) => waterTile.GetTile(pos) == null;

}

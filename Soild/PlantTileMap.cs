using UnityEngine.Tilemaps;
using UnityEngine;
using System;

[Serializable]
public class PlantTileMap
{
    [SerializeField] private Tilemap plantTile;

    public Vector3Int WorldToCell(Vector3 worldPos) => plantTile.WorldToCell(worldPos);
    public void SetTile(Vector3Int pos, TileBase tile) => plantTile.SetTile(pos, tile);
    public TileBase GetTile(Vector3Int pos) => plantTile.GetTile(pos);
    public BoundsInt GetBounds() => plantTile.cellBounds;
    public bool IsEmpty(Vector3Int pos) => plantTile.GetTile(pos) == null;

}

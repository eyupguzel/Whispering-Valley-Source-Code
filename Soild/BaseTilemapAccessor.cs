using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class BaseTilemapAccessor
{
    [SerializeField] private Tilemap baseTilemap;

    public TileBase GetTile(Vector3Int pos) => baseTilemap.GetTile(pos);
    public Vector3Int WorldToCell(Vector3 worldPos) => baseTilemap.WorldToCell(worldPos);
    public BoundsInt GetBounds() => baseTilemap.cellBounds;
}

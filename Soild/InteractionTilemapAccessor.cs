using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class InteractionTilemapAccessor
{
    [SerializeField] private Tilemap interactionTilemap;
    public Vector3Int WorldToCell(Vector3 worldPos) => interactionTilemap.WorldToCell(worldPos);

    public void SetTile(Vector3Int pos, TileBase tile) => interactionTilemap.SetTile(pos, tile);
    public TileBase GetTile (Vector3Int pos) => interactionTilemap.GetTile(pos);
    public BoundsInt GetBounds() => interactionTilemap.cellBounds;
    public bool IsEmpty(Vector3Int pos) => interactionTilemap.GetTile(pos) == null;

}

using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Tile/SoilTile")]
public class CustomSoilTileSO : Tile
{
    public TileBase tileBase;

    public void Plow(Tilemap tilemap, Vector3Int position)
    {
        tilemap.SetTile(position, tileBase);
    }
}

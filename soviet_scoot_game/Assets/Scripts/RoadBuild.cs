using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadBuild : MonoBehaviour
{

    public Vector3Int startPosition;
    public Vector3Int startSize;
    public Vector3Int endPosition;
    public Vector3Int endSize;

    void Awake()
    {
        Tilemap tilemap = GetComponent<Tilemap>();
        Vector3Int position = new Vector3Int(0, -4, 0);
        Vector3Int size = new Vector3Int(3, 5, 1);

        BoundsInt area = new BoundsInt(position, size);

        TileBase[] tileArray = tilemap.GetTilesBlock(area);

        Vector3 sceneDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        int repeat = (int)((sceneDimensions.x - 3)/3) + 2; // offset it by two

        for (int i = 1; i <= repeat; i++){
            tilemap.SetTilesBlock(new BoundsInt(position + Vector3Int.right * 3 * i, size), tileArray);
        }

        // we add +1 to repeat because the tiles we get are in 0-1-2. So they are already going forward,
        // thus we need one more repetition to cover the back road
        for (int i = 1; i <= repeat + 1; i++)
        {
            tilemap.SetTilesBlock(new BoundsInt(position - Vector3Int.right * 3 * i, size), tileArray);
        }

        startPosition = position - Vector3Int.right * 3 * (repeat + 1);
        startSize = size;

        endPosition = position + Vector3Int.right * 3 * (repeat + 1);
        endSize = size;

    }

}

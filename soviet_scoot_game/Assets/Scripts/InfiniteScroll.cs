using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Izge Bayyurt
// This code copies the tiles for the road to make it scroll infinitely

public class InfiniteScroll : MonoBehaviour
{

    public float scrollSpeed = 2.0f;
    public bool scrollEnable;

    private Transform tr;
    private Vector3 nextPos; // the position to be scrolled to

    // Bounds for tilemap offset
    public Vector3Int startPosition;
    public Vector3Int startSize;

    public Vector3Int endPosition;
    public Vector3Int endSize;

    private BoundsInt startTileArea;
    private BoundsInt endTileArea;

    private TileBase[] tileArray;
    private Tilemap tilemap;

    private void Start()
    {
        tr = transform;
        nextPos = transform.position + Vector3.left;
        tilemap = GetComponent<Tilemap>();

        startTileArea = new BoundsInt(startPosition, startSize);
        endTileArea = new BoundsInt(endPosition, endSize);
    }

    private void Update()
    {

        if(scrollEnable){

            if (transform.position != nextPos){
                transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * scrollSpeed);

            } else {

                nextPos += Vector3.left;

                // Tile offsetting
   
                tileArray = tilemap.GetTilesBlock(startTileArea);

                tilemap.SetTilesBlock(endTileArea, tileArray);

                tilemap.SetTilesBlock(startTileArea, new TileBase[5]);

                endPosition += Vector3Int.right;
                endTileArea = new BoundsInt(endPosition, endSize);

                startPosition += Vector3Int.right;
                startTileArea = new BoundsInt(startPosition, startSize);

            }

        }




    }



}

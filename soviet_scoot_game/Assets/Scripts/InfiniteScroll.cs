using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Izge Bayyurt
// This code copies the tiles for the road to make it scroll infinitely

public class InfiniteScroll : MonoBehaviour
{

    public float scrollSpeed = 4.0f;
    public bool scrollEnable;

    private Transform tr;
    private Vector3 nextPos; // the position to be scrolled to

    // Bounds for tilemap offset
    private RoadBuild roadBuild;

    private Vector3Int startPosition;
    private Vector3Int startSize;

    private Vector3Int endPosition;
    private Vector3Int endSize;

    private BoundsInt startTileArea;
    private BoundsInt endTileArea;

    private TileBase[] tileArray;
    private Tilemap tilemap;

    private void Start()
    {
        tr = transform;
        nextPos = transform.position + 3 * Vector3.left;
        tilemap = GetComponent<Tilemap>();

        roadBuild = GetComponent<RoadBuild>();

        startPosition = roadBuild.startPosition;
        startSize = roadBuild.startSize;

        endPosition = roadBuild.endPosition;
        endSize = roadBuild.endSize;

        Debug.Log(startPosition);
        Debug.Log(startSize);
        Debug.Log(endPosition);
        Debug.Log(endSize);

        startTileArea = new BoundsInt(startPosition, startSize);
        endTileArea = new BoundsInt(endPosition, endSize);



    }

    private void Update()
    {

        if(scrollEnable){

            if (transform.position != nextPos){

                transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * scrollSpeed);

            } else {

                nextPos += 3 * Vector3.left;

                // Tile offsetting

                tileArray = tilemap.GetTilesBlock(startTileArea);

                Debug.Log(tileArray.Length);
                Debug.Log(endTileArea);

                // set the new tiles
                tilemap.SetTilesBlock(endTileArea, tileArray);

                // delete the old tiles
                tilemap.SetTilesBlock(startTileArea, new TileBase[15]);

                endPosition += Vector3Int.right * 3;
                endTileArea = new BoundsInt(endPosition, endSize);

                startPosition += Vector3Int.right * 3;
                startTileArea = new BoundsInt(startPosition, startSize);

            }

        }




    }



}

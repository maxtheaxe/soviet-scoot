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

        startTileArea = new BoundsInt(startPosition, startSize);
        endTileArea = new BoundsInt(endPosition, endSize);


        GameManager.Instance.SetRoadSpeed(scrollSpeed);
        GameManager.Instance.origRoadSpeed = scrollSpeed;
    }

    private void Update()
    {
        //This is probably pointless but it's there for now so watch out :)
        if(GameManager.Instance.GetRoadSpeed() != scrollSpeed)
        {
            scrollSpeed = GameManager.Instance.GetRoadSpeed();
            if(scrollSpeed < 0)
            {
                scrollSpeed = 0;
            }
        }

        if(scrollEnable){

            if (transform.position != nextPos){

                transform.position = Vector3.MoveTowards(transform.position, nextPos, Time.deltaTime * scrollSpeed);

                // smoothing out the movement
                //Vector3 fixedPosition = new Vector3(Mathf.RoundToInt(unfixedPosition.x * 256),
                //                                     Mathf.RoundToInt(unfixedPosition.y * 256));

                //transform.position = fixedPosition / 256;

            } else {

                nextPos += 3 * Vector3.left;

                // Tile offsetting

                tileArray = tilemap.GetTilesBlock(startTileArea);

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

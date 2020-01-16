using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleSpawnerGrid : MonoBehaviour
{

    public TileBase obstacle;

    public int spawnCD = 3;
    public int spawnCount = 1;

    private Tilemap parentTilemap;
    private Tilemap tilemap;

    private bool spawning = false;
    private BoundsInt spawnPoints;

    private Vector3Int spawnTile;
    private Vector3Int lastSpawnPoint = new Vector3Int(0, 0, 0);

    private List<Vector3Int> spawnedObstacles = new List<Vector3Int>();

    private void Awake()
    {
        parentTilemap = transform.parent.GetComponent<Tilemap>();
        tilemap = GetComponent<Tilemap>();
    }

    private void Update()
    {

        if (!spawning)
        {
            StartCoroutine("SpawnObstacle");
        }

        if (spawnedObstacles.Count != 0){
            if (tilemap.CellToWorld(spawnedObstacles[0]).x < -11)
            {
                tilemap.SetTile(spawnedObstacles[0], null);
                spawnedObstacles.RemoveAt(0);
            }
        }


    }

    IEnumerator SpawnObstacle()
    {
        spawning = true;
        yield return new WaitForSeconds(spawnCD);

        spawnPoints =
                new BoundsInt(new Vector3Int(parentTilemap.cellBounds.xMax,
                                             parentTilemap.cellBounds.yMin, 0),
                              new Vector3Int(0, 5, 1));



        for (int i = 0; i < spawnCount; i++)
        {
            spawnTile = new Vector3Int(Random.Range(spawnPoints.xMin, spawnPoints.xMax + 1),
                                       Random.Range(spawnPoints.yMin, spawnPoints.yMax), 0);                         

            if (spawnTile == lastSpawnPoint)
            {
                continue;
            }

            lastSpawnPoint = spawnTile;

            spawnedObstacles.Add(spawnTile);

            tilemap.SetTile(spawnTile, obstacle);

        }

        spawning = false;

    }

}





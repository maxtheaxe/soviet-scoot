using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacleList; // list for obstacles
    public List<GameObject> coinList; // list for coins
    public float spawnCD = 0.1f;
    public int spawnCount = 1;
    public int xSpawnOffset = 30;
    public float obstacleSpeed = 10;
    public float minSpawnCD = 0.2f;
    public bool movingObstacle = false;
    public Tilemap tileMap;

    private List<Vector3> spawnPoints;
    private bool spawning = false;
    private int lastSpawnPointIdx = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.origSpawnCD = spawnCD;

        spawnPoints = new List<Vector3>();

        for(int c = tileMap.cellBounds.xMax/2; c < tileMap.cellBounds.xMax; c++)
        {
            for (int r = tileMap.cellBounds.yMin; r < tileMap.cellBounds.yMax; r++)
            {
                Vector3Int localPoint = new Vector3Int(c, r, (int)tileMap.transform.position.y);
                Vector3 point = tileMap.CellToWorld(localPoint);

                if(tileMap.HasTile(localPoint))
                {
                    spawnPoints.Add(point);
                }
            }

        }



    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPoints.Count == 0)
        {
            Debug.LogWarning("0 possible obstacle spawn points for some reason! Fix pl0x");
        }

        if (GameManager.Instance.GetSpawnCD() != spawnCD)
        { 
            spawnCD = spawnCD <= minSpawnCD ? minSpawnCD : GameManager.Instance.GetSpawnCD();
        }

        if(!spawning)
        {
            StartCoroutine("SpawnObstacle");
        }

    }


    IEnumerator SpawnObstacle()
    {
       spawning = true;
       yield return new WaitForSeconds(spawnCD);

       for(int i = 0; i < spawnCount; i++)
       {
            int listEntry = Random.Range(0, spawnPoints.Count);

            if(listEntry == lastSpawnPointIdx)
            {
                continue;
            }

            lastSpawnPointIdx = listEntry;

            GameObject spawnObject;

            if (Random.value < GameManager.Instance.coinSpawnRate){
                spawnObject = coinList[Random.Range(0, coinList.Count)];
            } else {
                spawnObject = obstacleList[Random.Range(0, obstacleList.Count)];
            }

            var objInstance = Instantiate(spawnObject, spawnPoints[listEntry] + new Vector3(xSpawnOffset, 0.5f, 0 ), Quaternion.identity);

            if(objInstance.GetComponent<SpriteRenderer>().isVisible )
            {
                objInstance.transform.position = new Vector3(objInstance.transform.position.x + 10, objInstance.transform.position.y, 0);
            }

            if(!movingObstacle)
            {
                objInstance.transform.parent = tileMap.transform;
            }
            else
            {
                ObstacleMove moveScript = spawnObject.GetComponent<ObstacleMove>();
                if(moveScript != null)
                {
                    moveScript.speed = obstacleSpeed;
                }
            }
            
       }

        spawning = false;
    }

}

    



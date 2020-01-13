using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public Tilemap tilemap;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if (tilemap.GetTile(tilemap.WorldToCell(tr.position)) != null){

            if (tilemap.GetTile(tilemap.WorldToCell(tr.position)).name == "barrel_1")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
}

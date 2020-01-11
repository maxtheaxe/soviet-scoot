using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* taken from robertbu https://answers.unity.com/questions/611343/movement-2d-in-a-grid.html
 * repurposed for the game and edited into C# by Izge Bayyurt
 */  

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public int lanes = 5;

    private int currentLane;
    private Vector3 pos;
    private Transform tr;

    private void Start()
    {
        pos = transform.position;
        tr = transform;

        currentLane = (lanes / 2) + 1;
    }


    private void Update()
    {   

        if (Input.GetAxisRaw("Vertical") > 0 && tr.position == pos && currentLane < lanes) // up
        {
            pos += Vector3.up;
            currentLane += 1;

        }
        else if (Input.GetAxisRaw("Vertical") < 0 && tr.position == pos && currentLane > 1) // down
        {
            pos += Vector3.down;
            currentLane -= 1;
        }

        if(pos != tr.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }


    }
}

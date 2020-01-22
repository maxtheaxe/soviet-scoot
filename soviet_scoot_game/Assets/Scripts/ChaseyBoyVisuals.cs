using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseyBoyVisuals : MonoBehaviour
{
    public GameObject chaseArrow;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveBack()
    {
        var tarPos = new Vector3(chaseArrow.transform.position.x - 10, chaseArrow.transform.position.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, tarPos, Time.deltaTime * 5);
    }

    public void FirstMove()
    {
        var tarPos = new Vector3(chaseArrow.transform.position.x - 2, chaseArrow.transform.position.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, tarPos, Time.deltaTime * 2);
    }

    public void SecondMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 2);
    }

}

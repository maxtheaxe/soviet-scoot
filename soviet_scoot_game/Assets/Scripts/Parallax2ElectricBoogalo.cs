using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2ElectricBoogalo : MonoBehaviour
{

    private float length;
    private float startPos;
    public float parralaxAmount;
    public GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parralaxAmount));

        float dist = (camera.transform.position.x * parralaxAmount);
        transform.position = new Vector3(startPos * dist, transform.position.y, transform.position.z);

        //if(temp > startPos + length)
        //{
        //    startPos += length;
        //}
        //else if(temp < startPos - length)
        //{
        //    startPos -= length;
        //}
    }
}

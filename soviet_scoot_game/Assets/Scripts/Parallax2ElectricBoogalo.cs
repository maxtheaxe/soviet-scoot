using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2ElectricBoogalo : MonoBehaviour
{

    public List<GameObject> sprites;
    public float parallaxEffect = 0.2f;
    public Vector3 initialPos;

    private GameManager gm;
    private Queue<GameObject> spriteQ;
    private bool wasVis;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        spriteQ = new Queue<GameObject>();
        wasVis = false;

        foreach(GameObject obj in sprites)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(-gm.GetRoadSpeed() * parallaxEffect, 0, 0);

            spriteQ.Enqueue(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer sr = spriteQ.Peek().GetComponent<SpriteRenderer>();

        if(sr.isVisible)
        {
            wasVis = true;
        }

        if(wasVis && !sr.isVisible)
        {
            var poppedObj = spriteQ.Dequeue();

            var rb = poppedObj.GetComponent<Rigidbody2D>();
            var tempVel = rb.velocity;

            poppedObj.transform.position = initialPos;
            rb.velocity = tempVel;
            sprites.Remove(poppedObj);

            sprites.Add(poppedObj);
            spriteQ.Enqueue(poppedObj);

            wasVis = false;

        }



        var roadSpeed = gm.GetRoadSpeed();
        foreach (GameObject obj in sprites)
        {
            obj.GetComponent<Rigidbody2D>().velocity = new Vector3(-roadSpeed * parallaxEffect, 0, 0);
        }

        




    }
}

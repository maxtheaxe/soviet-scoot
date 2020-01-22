using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChaseyBoyMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject chaseyBoi;
    public float speed = 10.0f;
    public float maxSpeed = 100.0f;
    public float distance = 7000.0f;
    public float maxDistance = 10000.0f;
    public float threshold0 = 8000.0f;
    public float threshold1 = 5000.0f;
    public float threshold2 = 2000.0f;
    public float threshold3 = 0.0f;

    private Animator anim;
    private GameManager gm;
    private SpriteRenderer sr;

    private float origSpeed;
    private bool movedBack = true;
    private bool justMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        gm = GameManager.Instance;
        origSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 5 && gm.justCollided)
        {
            speed /= 1.2f;
        }
        speed += (maxSpeed / 50) / speed;

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        distance -= speed;
        distance += gm.GetRoadSpeed();

        if (distance > maxDistance)
        {
            distance = maxDistance;
        }


        //print("DI:" + distance + " RS: " + gm.GetRoadSpeed());

        if (distance < threshold3)
        {
            anim.speed = 6;

            ChaseyBoyVisuals cbs = chaseyBoi.GetComponent<ChaseyBoyVisuals>();
            cbs.SecondMove();
        }
        else if (distance < threshold2)
        {
            anim.speed = 3;
            
            ChaseyBoyVisuals cbs = chaseyBoi.GetComponent<ChaseyBoyVisuals>();
            cbs.FirstMove();

        }
        else if (distance < threshold1)
        {
            anim.speed = 2;
        }
        else if (distance < threshold0)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }

        if (distance > threshold2)
        {
            ChaseyBoyVisuals cbs = chaseyBoi.GetComponent<ChaseyBoyVisuals>();
            cbs.MoveBack();
        }

        if (transform.position.y != player.transform.position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, player.transform.position.y, 0.0f), Time.deltaTime * speed * 3);
        }

    }

    IEnumerator RespitePeriod()
    {
        justMoved = true;
        yield return new WaitForSeconds(3);
        justMoved = false;
    }

}

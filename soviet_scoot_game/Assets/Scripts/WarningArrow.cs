using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject player;
    public float xOffset = 17;

    private SpriteRenderer sr;
    private bool seen;
    private bool created;
    private GameObject arrowRef;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        seen = false;
        created = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!seen && !sr.isVisible && !created)
        {
            created = true;
            arrowRef = Instantiate(arrow, new Vector3(player.transform.position.x + xOffset, transform.position.y+.3f, 0), Quaternion.identity);
            Destroy(arrowRef, 5.0f);
        }

        if(sr.isVisible)
        {
            seen = true;
        }

        if(sr.isVisible && created)
        {
            created = false;
        }


    }


}

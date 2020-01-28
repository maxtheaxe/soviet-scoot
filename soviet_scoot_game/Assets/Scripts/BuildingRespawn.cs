using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingRespawn : MonoBehaviour
{

    private bool seen;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        seen = false;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.isVisible)
        {
            seen = true;
            Debug.Log("seen");
        }

        if(seen)
        {
            Debug.Log("seen2");
            if (!sr.isVisible)
            {
                Debug.Log("unseen");
                seen = false;
                transform.position += Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) + new Vector3(sr.sprite.rect.width,0);

                float randomOffset = Random.value * Screen.width;
                transform.position += new Vector3(randomOffset, 0);

            }
        }



    }
}

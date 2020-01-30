using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class DisplayDistance : MonoBehaviour
{
    public Tilemap road;
    public int distanceLeft;

    private TextMeshProUGUI tm;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        tm = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceLeft = (int)(gm.winDistance + road.transform.position.x); //road transform position is negative, hence the addition.
        gm.SetDistanceComplete((int) -road.transform.position.x);

        tm.text = "End in: " + distanceLeft + " units";
    }
}

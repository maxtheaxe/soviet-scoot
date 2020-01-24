using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class DisplayDistance : MonoBehaviour
{
    public Tilemap road;

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
        int distance = (int)(gm.winDistance + road.transform.position.x); //road transform position is negative, hence the addition.

        tm.text = "End in: " + distance + " units";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
    private GameManager gm;
    private TextMeshProUGUI tm;

    // Start is called before the first frame update
    void Start()
    {
        tm = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gm = GameManager.Instance;
        tm.text = "Coins: " + gm.GetCoins();
    }
}

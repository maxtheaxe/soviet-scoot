using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckCoins : MonoBehaviour
{
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
        if (gm.GetCoins() < gm.minCoinCount)
        {
            GetComponent<Button>().interactable = false;
            Debug.Log("Inside the if loop");
        }
    }
}

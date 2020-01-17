using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* To access the stuff in this class you would do GameManager.Instance.field/method */


    private static GameManager instance = null;

    public int coins;
    public float roadSpeed;


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "SingletonController";
                    instance = go.AddComponent<GameManager>();
                    //GameManager.instance.loadEverything();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCoins()
    {
        return this.coins;
    }

    public void AddCoins()
    {
        this.coins++;
    }

    public void AddCoins(int coinCount)
    {
        this.coins += coinCount;
    }

    public void SetCoins(int newCoinCount)
    {
        this.coins = newCoinCount;
    }

    public float GetRoadSpeed()
    {
        return this.roadSpeed;
    }

    public void SetRoadSpeed(float newSpeed)
    {
        this.roadSpeed = newSpeed;

    }



}

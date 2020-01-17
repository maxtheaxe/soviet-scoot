using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /* To access the stuff in this class you would do GameManager.Instance.field/method */


    private static GameManager instance = null;

    public int coins;
    public float roadSpeed;
    public float playerSpeed;
    public float spawnCD = 2.0f;

    public float origRoadSpeed;
    public float origPlayerSpeed;
    public float origSpawnCD;

    private bool scalingDif = false;
    
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

        roadSpeed = 10;
    }

    void Update()
    {
        if(!scalingDif)
        {
            StartCoroutine("ScaleDifficulty");
        }
    }



    IEnumerator ScaleDifficulty()
    {
        scalingDif = true;
        yield return new WaitForSeconds(1);

        roadSpeed -= 1;
        playerSpeed += 1;
        spawnCD *= 0.95f;

        scalingDif = false;
    }

    public void DoubleSpawnCD()
    {
        spawnCD *= 1.4f;
    }

    public void ResetDifficulty()
    {
        roadSpeed = origRoadSpeed;
        playerSpeed = origPlayerSpeed;
        spawnCD = origSpawnCD;
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

    public float GetPlayerSpeed()
    {
        return this.playerSpeed;
    }

    public void SetPlayerSpeed(float newSpeed)
    {
        this.playerSpeed = newSpeed;
    }

    public float GetSpawnCD()
    {
        return this.spawnCD;
    }

    public void SetSpawnCD(float newSpawnCD)
    {
        this.spawnCD = newSpawnCD;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* taken from robertbu https://answers.unity.com/questions/611343/movement-2d-in-a-grid.html
 * repurposed for the game and edited into C# by Izge Bayyurt
 */  

public class PlayerMovement : MonoBehaviour
{
    public GameObject camera;
    public float speed = 5.0f;
    public int lanes = 5;
    public float kickCD = 1.0f;


    private int currentLane;
    private Vector3 pos;
    private Transform tr;
    private bool kickCoolingDown = false;

    private void Start()
    {
        pos = transform.position;
        tr = transform;

        currentLane = (lanes / 2) + 1;

        GameManager.Instance.origPlayerSpeed = speed;
    }


    private void Update()
    {   

        if(GameManager.Instance.GetPlayerSpeed() > 5 && GameManager.Instance.GetPlayerSpeed() != speed)
        {
            speed = GameManager.Instance.GetPlayerSpeed();
            if(speed >= 10.0f)
            {
                speed = 10.0f;
            }
        }

        if (Input.GetAxisRaw("Vertical") > 0 && tr.position == pos && currentLane < lanes) // up
        {
            pos += Vector3.up;
            currentLane += 1;

        }
        else if (Input.GetAxisRaw("Vertical") < 0 && tr.position == pos && currentLane > 1) // down
        {
            pos += Vector3.down;
            currentLane -= 1;
        }

        if(pos != tr.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && !kickCoolingDown)
        {
            StartCoroutine("Kick");
        }

    }

    IEnumerator Kick()
    {
        kickCoolingDown = true;
        GameManager.Instance.SetRoadSpeed(GameManager.Instance.GetRoadSpeed() + 100/GameManager.Instance.roadSpeed);

        yield return new WaitForSeconds(kickCD);

        kickCoolingDown = false;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        var gm = GameManager.Instance;

        if(col.gameObject.tag == "Chaser")
        {
            gm.caught = true;
        }
        
        if (col.gameObject.tag == "Obstacle")
        {
            gm.SetRoadSpeed(gm.GetRoadSpeed() / 2);
            gm.DoubleSpawnCD();

            var shaker = camera.GetComponent<ScreenShake>();
            shaker.TriggerShake(0.5f,0.3f,1.0f);

            GameManager.Instance.justCollided = true;
        }

        if (col.gameObject.tag.Substring(0, 4) == "Coin")
        {
            switch (col.gameObject.tag)
            {
                case "Coin_g":
                    gm.AddCoins(gm.GetGoldCoinValue());
                    break;
                case "Coin_s":
                    gm.AddCoins(gm.GetSilverCoinValue());
                    break;
                case "Coin_b":
                    gm.AddCoins(gm.GetBronzeCoinValue());
                    break;
            }

            Destroy(col.gameObject);

        }
            //GameManager.Instance.ResetDifficulty();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

}



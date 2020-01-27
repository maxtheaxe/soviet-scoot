using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public List<Transform> buildings;
    public float buildingParallax = 0.2f;
    public float addedDist;
    public Vector3 initialPos;

    private float roadSpeed;
    private bool addNew;
    private List<bool> seenList;
    private Stack<GameObject> spriteStack;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            switch (transform.GetChild(i).tag)
            {
                case "Building":
                    buildings.Add(transform.GetChild(i));;
                    break;
            }
        }

        seenList = new List<bool>();
        addNew = false;

        for(int i = 0; i < buildings.Count; i++)
        {
            seenList.Add(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        roadSpeed = GameManager.Instance.GetRoadSpeed();


        if(addNew)
        {

        }

        for (int i = 0; i < buildings.Count; i++){
            if(buildings[i].GetComponent<Rigidbody2D>() != null)
            {
                buildings[i].GetComponent<Rigidbody2D>().velocity = new Vector3(-roadSpeed * buildingParallax,0,0);

                SpriteRenderer sr = buildings[i].GetComponent<SpriteRenderer>();
                if (seenList[i] == false && sr.isVisible)
                {
                    seenList[i] = true;
                }

                if (sr.isVisible == false && seenList[i] == true)
                {
                    //buildings[i].transform.position = initialPos;
                    addNew = true;
                    seenList[i] = false;
                }

            }
            else
            {
                Debug.Log("Rigidbody not found on background element");
            }
        }

    }
}

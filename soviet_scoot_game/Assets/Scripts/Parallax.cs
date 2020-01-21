using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public List<Transform> buildings;
    public float buildingParallax = 0.2f;

    private float roadSpeed;

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
    }

    // Update is called once per frame
    void Update()
    {
        roadSpeed = GameManager.Instance.GetRoadSpeed();

        for (int i = 0; i < buildings.Count; i++){
            if(buildings[i].GetComponent<Rigidbody2D>() != null){
                buildings[i].GetComponent<Rigidbody2D>().velocity = new Vector3(-roadSpeed * buildingParallax,0,0);
            } else {
                Debug.Log("Rigidbody not found on background element");
            }
        }

    }
}

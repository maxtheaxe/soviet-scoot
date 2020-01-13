using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Izge Bayyurt
// ScriptableObject class for obstacles

[System.Serializable]
public class ScriptableObstacle : ScriptableObject
{
    public Sprite image;
    public int length; // length of the image (1 unit is 16x16)
    public int width; // width of the image
    public bool isStationary;

}

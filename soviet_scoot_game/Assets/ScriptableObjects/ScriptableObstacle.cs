using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Izge Bayyurt
// ScriptableObject class for obstacles

[System.Serializable]
public class ScriptableObstacle : ScriptableObject
{
    private Sprite image;
    private int length; // length of the image (1 unit is 16x16)
    private int width; // width of the image
    private bool isStationary;


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBoundary : MonoBehaviour
{
    public static float leftBorder;
    public static float rightBorder; 

    void Awake()
    {
        leftBorder = -1 * transform.localScale.x / 2;
        rightBorder = transform.localScale.x / 2;
    }
}

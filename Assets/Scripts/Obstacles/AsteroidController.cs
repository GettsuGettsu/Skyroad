using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private readonly float yAngle = 100f;
    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.Rotate(0, yAngle * Time.fixedDeltaTime, 0);
        transform.position = startPosition;
    }
}

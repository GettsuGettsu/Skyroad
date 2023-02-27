using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float sidesSpeed;
    public static float moveSpeed;
    public static float moveSpeedMultiplier;
    private readonly float yPosition = 0.5f;
    private readonly float maxMoveSpeed = 200;
    private readonly float startAcceleration = 20f;
    private readonly float defaultMoveSpeed = 2f;
    private readonly float moveSpeedIncrement = 0.001f;
    private readonly float rotationAngle = 45f;

    private void Awake()
    {
        sidesSpeed = 5f;
        moveSpeed = 0f;
        moveSpeedMultiplier = 1f;
    }

    void Update()
    {
        if (Time.timeScale == 0)
            return;

        // slowly speeds up from 0 to default move speed
        if (moveSpeed < defaultMoveSpeed)
            moveSpeed += startAcceleration * moveSpeedIncrement;
        // continuously increases the move speed of the ship
        else
            moveSpeed += moveSpeedIncrement;

        sidesSpeed += moveSpeedIncrement / 5;

        moveSpeed = Mathf.Clamp(moveSpeed, 0, maxMoveSpeed);
        sidesSpeed = Mathf.Clamp(sidesSpeed, 0, maxMoveSpeed / 5);

        if (Input.GetKey(KeyCode.Space))
            moveSpeedMultiplier = 2f;
        else
            moveSpeedMultiplier = 1f;

        float horizontalAxisValue = Input.GetAxis("Horizontal");
        transform.Translate(horizontalAxisValue * sidesSpeed * Time.deltaTime, 0, moveSpeedMultiplier * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(transform.eulerAngles.z, -horizontalAxisValue * rotationAngle, Time.deltaTime * 5));

        // limit the X position of the player to prevent from leaving the road
        var position = transform.position;
        position = new Vector3(Mathf.Clamp(position.x, FloorBoundary.leftBorder + transform.localScale.x / 2, FloorBoundary.rightBorder - transform.localScale.x / 2), yPosition, position.z);
        transform.position = position;
    }
}

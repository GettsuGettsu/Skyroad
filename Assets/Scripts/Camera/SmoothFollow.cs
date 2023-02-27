using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public float distance = 1.5f;
    public float height = 0.8f;
    public float heightDamping = 0.5f;
    public float rotationDamping = 3.0f;
    public Transform target;

    private void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
        {
            return;
        }

        float wantedDistance = Input.GetKey(KeyCode.Space) ? distance / 3 : distance;
        float currentDistance = target.position.z - transform.position.z;

        // Calculate the current rotation angles
        float wantedHeight = target.position.y + height;

        float currentHeight = transform.position.y;

        currentDistance = Mathf.Lerp(currentDistance, wantedDistance, ShipController.moveSpeed * ShipController.moveSpeedMultiplier * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        var pos = transform.position;
        pos = new Vector3(target.position.x, currentHeight, target.position.z - currentDistance);
        transform.position = pos;
    }
}
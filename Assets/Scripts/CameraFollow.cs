
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float SmoothSpeed = 0.5f;
    public Vector3 offset;
    public bool LockOnPlayer;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        if (LockOnPlayer == true)
            transform.LookAt(target);
    }




}

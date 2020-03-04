using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public bool SmoothRotation = false;
    public float TowerRotateSpeed;
    public Transform TankBody;
    public Vector3 offset;



    private void FixedUpdate()
    {
        transform.position = TankBody.position + offset;

        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            if (SmoothRotation)
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TowerRotateSpeed * Time.deltaTime);
            else
                transform.rotation = targetRotation;
        }
    }
}

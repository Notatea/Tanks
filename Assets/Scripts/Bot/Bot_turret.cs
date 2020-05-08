using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_turret : MonoBehaviour
{
    public bool SmoothRotation = false;
    public float TowerRotateSpeed;
    public Transform TankBody;
    public Vector3 offset;
    public Transform Enemy;
    public bool Fire = false;
    public float enemyDistance;
    float distance;
    public bool move;

    private void FixedUpdate()
    {
        transform.position = TankBody.position + offset;

        float hitdist = 0.0f;

        RaycastHit hit;
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - Enemy.transform.position.x, 2) + Mathf.Pow(transform.position.z - Enemy.transform.position.z, 2));

        if (distance <= enemyDistance)
            move = true;
        else
            move = false;

        if (Physics.Raycast(gameObject.transform.position, Enemy.position - gameObject.transform.position, out hit, 100.0f) )//Есть пересечение
        {
            if (hit.transform.tag == "Enemy" && distance <= enemyDistance)
            {

                Vector3 targetPoint = Enemy.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                if (SmoothRotation)
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, TowerRotateSpeed * Time.deltaTime);
                else
                    transform.rotation = targetRotation;
                Fire = true;
             }
            else
                Fire = false;
        }
          
    }
}


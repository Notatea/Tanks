using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_movement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 movement;
    public float boost = 2.0f;
    public float RotationSmoothness = 50.0f;
    public GameObject Turet;

    float speedboost;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Turet.GetComponent<Bot_turret>().move)
        {
            movement = Turet.GetComponent<Bot_turret>().Enemy.position - gameObject.transform.position;
            float vect_lenght = Mathf.Sqrt((movement.x * movement.x) + (movement.y * movement.y) + (movement.z * movement.z));
            movement = movement / vect_lenght;
        }
        else
            movement = Vector3.zero;
        

    }

    void FixedUpdate()
    {
        moveCharacter(movement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), RotationSmoothness * Time.deltaTime);
        }

    }

    void moveCharacter(Vector3 direction)
    {
        Debug.Log(direction.x);
        Debug.Log("\n");
        Debug.Log(direction.z);
        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}

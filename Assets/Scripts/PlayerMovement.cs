using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public Vector3 movement;
    public float boost = 2.0f;
    public float RotationSmoothness = 50.0f;

    float speedboost;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            speedboost = 1.0f;
          
        }
        else {
            speedboost = boost;
        
        }


        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

       /* if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement.normalized);
        }
        */

       
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
        // rb.velocity = direction * speed * speedboost;

        rb.MovePosition(transform.position + (direction * speed * speedboost * Time.deltaTime));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    GameObject prefab;
    public GameObject projectile;
    public float BulletSpeed = 10.0f;
    public float BulletOffset = 1.0f;
    public bool AutoFire;
    public float FireRate = 1f;
    public float BulletLifeTime = 1.0f;
    float nextFire = 0.0F;
    void Start()
    {

    }


    void Update()
    {

        if (AutoFire)
        {
       
    
         
            
            if (Input.GetMouseButton(0) && Time.time > nextFire)
            {
                nextFire = Time.time + 1/FireRate;
                Debug.Log("Shooted");


                GameObject bullet = Instantiate(projectile) as GameObject;
                bullet.transform.position = transform.position + transform.forward * BulletOffset;
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * BulletSpeed;
                Destroy(bullet, BulletLifeTime* Time.deltaTime);


            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire )
            {
                nextFire = Time.time + 1 / FireRate /2;
                Debug.Log("Shooted");

                GameObject bullet = Instantiate(projectile) as GameObject;
                bullet.transform.position = transform.position + transform.forward * BulletOffset;
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * BulletSpeed;
                Destroy(bullet, BulletLifeTime * Time.deltaTime);

            }
        }
        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_fire : MonoBehaviour
{
    GameObject prefab;
    public GameObject projectile;
    public float BulletSpeed = 10.0f;
    public float BulletOffset = 1.0f;
    public bool AutoFire;
    public float FireRate = 1f;
    public float BulletLifeTime = 1.0f;
    float nextFire = 0.0F;

    void Update()
    {
        bool fire = gameObject.GetComponent<Bot_turret>().Fire;

        if (fire  && Time.time > nextFire)
        {
            nextFire = Time.time + 1 / FireRate;

            GameObject bullet = Instantiate(projectile) as GameObject;
            bullet.transform.position = transform.position + transform.forward * BulletOffset;
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * BulletSpeed;
            Destroy(bullet, BulletLifeTime * Time.deltaTime);
        }
    }
}

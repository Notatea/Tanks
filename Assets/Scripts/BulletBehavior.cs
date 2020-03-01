using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject, 1);
    }
}

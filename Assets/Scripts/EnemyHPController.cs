using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{
    public float HP = 1.0f;
    public float ShrinkSpeed = 1.0f;
    public float DeathSpeed = 0.5f;


    private void FixedUpdate()
    {
        if (HP <= 0)
        { 
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, ShrinkSpeed/100);
            Destroy(gameObject, DeathSpeed);         
        }
    }

}



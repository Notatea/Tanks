using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPController : MonoBehaviour
{
    public float HP = 1.0f;
    public bool GetsDamage = false;
    public Color DamageColor;
    public float BlinkDuration = 1.0f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }


    private void FixedUpdate()
    {

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        else if (GetsDamage == true)
        {

            Blink();
           
            GetsDamage = false;
        }

        if(rend.material.color != Color.black)
        {
            
            Debug.Log("ColorChange2");
        }

    }

    private void Update()
    {
        rend.material.color = Color.Lerp(rend.material.color, Color.black, 1 / BlinkDuration);
    }


    void Blink()
    {
        rend.material.color = DamageColor;
        Debug.Log("ColorChange1");    
    }

}



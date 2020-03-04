using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    public float BlinkDuration = 50.0f;
    public bool GetsDamage = false;
    public Color DamageColor = Color.white;
    Renderer rend;  
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {

      if (GetsDamage == true)
        {

            Blink();

            GetsDamage = false;
        }

        if (rend.material.color != Color.black)
        {

            Debug.Log("ColorChange2");
        }

    }


    // Update is called once per frame`
    void Update()
    {
        rend.material.color = Color.Lerp(rend.material.color, Color.black, 1 / BlinkDuration);
    }


    void Blink()
    {
        rend.material.color = DamageColor;
        Debug.Log("ColorChange1");
    }
}

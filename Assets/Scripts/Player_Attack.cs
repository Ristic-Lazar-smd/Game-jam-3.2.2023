using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    public float weaponHealth = 20.0f;
   
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            Debug.Log("SDADSASADA");
            // isCurrentlyColliding = true;
            //Sprite Renderer flip z x y
        }
    }
}

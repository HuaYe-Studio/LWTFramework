using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.OnHurt = true;
            player.StartCoroutine(player.OnHurtTrigger());
        }
        Destroy(gameObject);
        
            
        
       
    }

    
}

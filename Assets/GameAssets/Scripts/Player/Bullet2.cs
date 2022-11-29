using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameAssets.Scripts;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
public class Bullet2 : HealthDependentBehaviour
{
    public float life = 10f;
    
    void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Health>().Remove(1);
            if (collision.gameObject.GetComponent<Health>().Current <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        // Destroy etsin asobservable a bak
        // 
    }
}
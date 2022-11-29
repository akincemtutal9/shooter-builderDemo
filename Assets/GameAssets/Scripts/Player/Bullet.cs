using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameAssets.Scripts;
using Lean.Pool;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;



public class Bullet : HealthDependentBehaviour
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
            Destroy(gameObject);
            if (collision.gameObject.GetComponent<Health>().Current <= 0)
            {
                LeanPool.Despawn(collision.gameObject);
            }
        }
        // Destroy etsin asobservable a bak
        // 
    }
}
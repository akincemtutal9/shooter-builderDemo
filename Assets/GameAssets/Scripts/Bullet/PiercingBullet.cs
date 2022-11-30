using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameAssets.Scripts;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class PiercingBullet : HealthDependentBehaviour
{
    public float life;
    public float damage;
    [SerializeField] private GameSettings _gameSettings;
    

    //public float shootTime;
    //public float waitForShootTime;
    void Start()
    {
        life = _gameSettings.piercingBulletLife;
        damage = _gameSettings.piercingBulletDamage;
        
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Health>().Remove((int)damage);
            if (collision.gameObject.GetComponent<Health>().Current <= 0)
            {
                Destroy(collision.gameObject);
            }
        }
        // Destroy etsin asobservable a bak
        // 
    }
}
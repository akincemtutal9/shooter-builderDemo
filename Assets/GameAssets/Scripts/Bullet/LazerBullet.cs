using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using GameAssets.Scripts;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class LazerBullet : HealthDependentBehaviour
{
    public float life;
    public float damage;
    public bool canShoot;
    public float shootTime;
    public float waitToShootInSeconds;

    [SerializeField] private GameSettings _gameSettings;

    private float timer;
  
    private void Start()
    {
        
      //  life = _gameSettings.lazerBulletLife;
       // damage = _gameSettings.lazerBulletdamage;
       // canShoot = _gameSettings.canLazerShoot;
       // shootTime = _gameSettings.lazerShootTime;
       // waitToShootInSeconds = _gameSettings.lazerWaitToShootInSeconds;
        
        Destroy(gameObject, life);
    }

    private void Update()
    {
       
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
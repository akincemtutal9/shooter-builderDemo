using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameAssets.Scripts;
using Lean.Pool;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeOfBullet;
    public int damage;
    
    [SerializeField] private GameSettings _gameSettings;
    
    void Start()
    {

        lifeOfBullet = _gameSettings.bulletObjectLife;
        damage = _gameSettings.bulletDamage;
        Destroy(gameObject, lifeOfBullet);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            collision.gameObject.GetComponent<Health>().Remove(damage);
            Destroy(gameObject);
        }
    }
}
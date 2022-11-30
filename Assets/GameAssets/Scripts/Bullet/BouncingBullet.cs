using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using GameAssets.Scripts;
using Lean.Pool;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class BouncingBullet : MonoBehaviour
{
    public float lifeOfBullet;
    public int damage;
    public PhysicMaterial physicMaterial;
    public int bouncingBullethowManyTimesBulletWillBounce;
    [SerializeField] private GameSettings _gameSettings;

    private int bounceBounceBounce;
    void Start()
    {
        lifeOfBullet = _gameSettings.bouncingBulletLife;
        damage = _gameSettings.bouncingBulletDamage;
        physicMaterial = _gameSettings.bouncingBulletPhysicMaterial;
        bouncingBullethowManyTimesBulletWillBounce = _gameSettings.bouncingBullethowManyTimesBulletWillBounce;
        Destroy(gameObject, lifeOfBullet);
        gameObject.GetComponent<SphereCollider>().isTrigger = false;
        gameObject.GetComponent<SphereCollider>().material = physicMaterial;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            bounceBounceBounce++;
            if (bounceBounceBounce >= bouncingBullethowManyTimesBulletWillBounce)
            {
                Destroy(gameObject);
            }
            collision.gameObject.GetComponent<Health>().Remove(damage);
            //Destroy(gameObject);
            if (collision.gameObject.GetComponent<Health>().Current <= 0)
            {
                LeanPool.Despawn(collision.gameObject);
            }
        }
        // Destroy etsin asobservable a bak
        // 
    }
}
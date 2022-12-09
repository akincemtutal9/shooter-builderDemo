using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    [SerializeField] public float nextFireCheck;
    [SerializeField] public float fireRate;

    [SerializeField] private GameSettings _gameSettings;
    
    private void Start()
    {
        bulletPrefab = _gameSettings.bulletPrefab;
        bulletSpeed = _gameSettings.shootSpeed;
        nextFireCheck = _gameSettings.shootNextFireCheck;
        fireRate = _gameSettings.shootFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }

    public void Shooting()
    {
        if (Time.time > nextFireCheck)
        {
            nextFireCheck = Time.time + fireRate;
            var bullet = LeanPool.Spawn(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed , ForceMode.Impulse);
        }
    }
}
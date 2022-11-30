using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    [SerializeField] float nextFireCheck;
    [SerializeField] float fireRate;

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
        if (Time.time > nextFireCheck)
        {
            nextFireCheck = Time.time + fireRate;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
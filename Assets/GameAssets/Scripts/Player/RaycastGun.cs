using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange;
    public float fireRate;
    public float laserDuration;
    public float waitForShootLaser;
    public int laserDamage;

    LineRenderer laserLine;
    private float timer;
    private bool canShoot;

    [SerializeField] private GameSettings _gameSettings;
    private PlayerRotate pr;

    
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        gunRange = _gameSettings.laserGunRange;
        fireRate = _gameSettings.laserGunFireRate;
        laserDuration = _gameSettings.laserDuration;
        laserDamage = _gameSettings.laserDamage;
        waitForShootLaser = _gameSettings.laserWaitForShoot;
        timer = 0f;

        StartCoroutine(StartLaser());
    }

    IEnumerator StartLaser()
    {
        while (true)
        {
            var laserShoot = StartCoroutine(ShootLaser());
            yield return new WaitForSeconds(laserDuration);// laser duration kadar sıkıyor
            Debug.Log("Stopping laser");
            StopCoroutine(laserShoot);
            laserLine.enabled = false;
            yield return new WaitForSeconds(waitForShootLaser);// wait for shoot laser kadar ateş etme.
        }
    }

    IEnumerator ShootLaser()
    {
        Debug.Log("starting laser");
        laserLine.enabled = true;
        
        while (true)
        {
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = laserOrigin.position;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, laserOrigin.transform.TransformDirection(Vector3.forward), out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                var health = hit.transform.GetComponent<Health>();
//                if (hit.collider.gameObject.CompareTag("Target"))
                if (health)
                {
                    // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                    health.Remove(laserDamage);
                    if (health.Current <= 0)
                    {
                        //Destroy(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                laserLine.SetPosition(1,
                    rayOrigin + (laserOrigin.transform.TransformDirection(Vector3.forward * gunRange)));
            }

            yield return new WaitForSeconds(fireRate);// fire rate kadar hasar veriyor olması
        }
        
    }
}
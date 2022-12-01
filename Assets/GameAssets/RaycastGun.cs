using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[RequireComponent(typeof(LineRenderer))]
public class RaycastGun : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float fireRate = 3f;
    public float laserDuration = 1f;
 
    LineRenderer laserLine;
    float fireTimer;
 
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        
    }

    void Update()
    {
        fireTimer += Time.deltaTime;
        if(fireTimer > fireRate)
        {
            fireTimer = 0;
            laserLine.SetPosition(0, laserOrigin.position);
            //Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Vector3 rayOrigin = laserOrigin.position;
            
            RaycastHit hit;
            if(Physics.Raycast(rayOrigin, laserOrigin.transform.TransformDirection(Vector3.forward), out hit, gunRange))
            {
                laserLine.SetPosition(1, hit.point);
                Destroy(hit.transform.gameObject);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (laserOrigin.transform.TransformDirection(Vector3.forward * gunRange)));
            }
            StartCoroutine(ShootLaser());
        }
    }
 
    IEnumerator ShootLaser()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
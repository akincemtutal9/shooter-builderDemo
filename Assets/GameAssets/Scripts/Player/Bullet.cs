using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;



public class Bullet : MonoBehaviour
{
    public float life = 10f;
    void Start()
    {
        Destroy(gameObject, life);
    }

}

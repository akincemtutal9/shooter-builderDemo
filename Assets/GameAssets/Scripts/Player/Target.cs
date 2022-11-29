using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float randomNumber;
    void Start()
    {
        randomNumber = UnityEngine.Random.Range(1, 10);
        transform.localScale = new Vector3(randomNumber, randomNumber, randomNumber);
    }
    void Update()
    {
        
    }
    public void DecreaseSize()
    {
        transform.localScale -= new Vector3(1, 1, 1);
    }
}

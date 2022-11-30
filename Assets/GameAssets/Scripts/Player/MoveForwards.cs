using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwards : MonoBehaviour
{
    [SerializeField] private float moveSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
    }
}

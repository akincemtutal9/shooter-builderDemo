using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Color;

public class AssignTag : MonoBehaviour
{
    private Color color;
    void Start()
    {
        color = GetComponent<Renderer>().material.color;
        if (color == Color.black)
        {
            gameObject.tag = "Black";
        }
        else if (color == Color.green)
        {
            gameObject.tag = "Green";
        }
        else if (color == Color.blue)
        {
            gameObject.tag = "Blue";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

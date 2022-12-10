using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour
{
    private Color[] colors = { Color.black, Color.blue, Color.green};
    void Start()
    { 
        GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsPlayer : MonoBehaviour
{
    private float distance;
    private Transform player;
    private Vector3 direction;
    public float goSpeed;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        var position = player.position;
        var position1 = transform.position;
        distance = Vector3.Distance(position , position1);
        direction = position - position1;

        position1 += direction.normalized * (goSpeed * Time.deltaTime);
        transform.position = position1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsPlayer : MonoBehaviour
{
    private float distance;
    private Transform player;
    private Vector3 direction;
    public float goSpeed;
    [SerializeField] private GameSettings _gameSettings;
    private Rigidbody rb;
    void Start()
    {
        goSpeed = _gameSettings.cylinderMoveSpeed;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = player.position;
        var transformPos = transform.position;
        distance = Vector3.Distance(playerPos , transformPos);
        direction = playerPos - transformPos;

        transformPos += direction.normalized * (goSpeed * Time.deltaTime);
        transform.position = transformPos;
    }
}

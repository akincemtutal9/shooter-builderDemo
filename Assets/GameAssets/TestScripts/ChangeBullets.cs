using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBullets : MonoBehaviour
{
    private GameSettings _gameSettings;

    public GameObject bulletBlue;

    public GameObject bulletGreen;

    public GameObject bulletBlack;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _gameSettings.bulletPrefab = bulletBlue;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _gameSettings.bulletPrefab = bulletBlack;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _gameSettings.bulletPrefab = bulletGreen;
        }
    }
}

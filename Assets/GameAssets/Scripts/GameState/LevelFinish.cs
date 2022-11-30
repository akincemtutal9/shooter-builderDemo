using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private Text levelFinishText;
    void Start()
    {
        levelFinishText.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelFinishText.text = "Level Finished";
            levelFinishText.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}

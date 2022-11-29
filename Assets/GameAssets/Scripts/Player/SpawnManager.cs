using System;
using Lean.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    //Fish Spawn Area
    [SerializeField] private GameObject SpawnArea;

    private float timer;
    
    [SerializeField] private float spawnAfterSeconds = 2f;
    [SerializeField] private GameObject spawnObjectPrefab;
    private float horizontalSpawnBoundries;
    private float verticalSpawnBoundries;
    private float xPosition;
    private float zPosition;
    private void Start()
    {
        var localScale = SpawnArea.transform.localScale;
        horizontalSpawnBoundries = localScale.x;
        verticalSpawnBoundries = localScale.z;
        var position = SpawnArea.transform.position;
        xPosition = position.x;
        zPosition = position.z;
        
    }
    private void Update()
    {
        RandomTargetSpawner();
    }

    private void RandomTargetSpawner()
    {
        timer += Time.deltaTime;
        if (timer > spawnAfterSeconds)
        {
            timer = 0;
            var randomSpawnPosition = new Vector3(Random.Range(-horizontalSpawnBoundries/2 + xPosition, horizontalSpawnBoundries/2 + xPosition), 0.5f, Random.Range(-verticalSpawnBoundries/2 + zPosition, verticalSpawnBoundries/2 + zPosition));
            //Instantiate(spawnFishObjectPrefab, randomSpawnPosition, Quaternion.identity);
            var spawnFishObject = LeanPool.Spawn(spawnObjectPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
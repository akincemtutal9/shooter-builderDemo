using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;
using Lean.Pool;
using TMPro;

namespace GameAssets.Scripts
{
    public class WorldGenerator : MonoBehaviour
    {
        [SerializeField] private Transform startingTransform;
        [SerializeField] private int count;
        [SerializeField] private RandomXZScale randomXZScale;
        [SerializeField] private GameObject prefab;
        [SerializeField] private float distanceMultiplier;

        [SerializeField] private int minHealth = 3;
        [SerializeField] private int maxHealth = 10;

        [SerializeField] private GameSettings _gameSettings;
        
        private void Start()
        {
            count = _gameSettings.howManyCylindersWillSpawn;
            randomXZScale = _gameSettings.CylinderRandomXZScale;
            prefab = _gameSettings.targetPrefab;
            distanceMultiplier = _gameSettings.distanceMultiplier;
            minHealth = _gameSettings.minHealth;
            maxHealth = _gameSettings.maxHealth;
            Generate();
        }
        
        private const string Root = nameof(Root);

        void Generate()
        {
            DestroyRoot();

            var root = new GameObject(Root);
            float distance = 0;
            for (int i = 0; i < count; i++)
            {
                var position = startingTransform.position;
                position.x = Mathf.Cos((float) i / count * 360 * Mathf.Deg2Rad) * distance *
                             (distanceMultiplier * (1 + (float) i / count));
                position.z = Mathf.Sin((float) i / count * 360 * Mathf.Deg2Rad) * distance *
                             (distanceMultiplier * (1 + (float) i / count));

                distance = randomXZScale.Randomize();

                var newTarget = LeanPool.Spawn(prefab, position, Quaternion.identity);
                var scale = newTarget.transform.localScale;
                scale.x = distance;
                scale.z = distance;
                newTarget.transform.localScale = scale;
                newTarget.transform.SetParent(root.transform);
                root.transform.GetChild(0).transform.gameObject.SetActive(false);
            }

            Observable.ReturnUnit().DelayFrame(1).Subscribe(_ =>
            {
                var healths = FindObjectsOfType<Health>();
                Array.ForEach(healths, health => health.Set(Random.Range(minHealth, maxHealth)));
            });
            
        }
        void DestroyRoot()
        {
            var root = GameObject.Find(Root);
            if (root)
            {
                if (Application.isEditor)
                    DestroyImmediate(root);
                else
                    Destroy(root);
            }
        }
    }
}